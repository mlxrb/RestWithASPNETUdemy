using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class TurmaBusinessImplementation : ITurmaBusiness
    {

        private readonly IRepository<Turma> _repository;
        private readonly ID2lRepository<CourseTemplateVO, CreateCourseTemplateVO, CourseTemplateInfoVO> _d2lRepository;
        private readonly ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lTypeUORepository;
        private readonly ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lOURepository;

        private readonly TurmaConverter _converter;

        public TurmaBusinessImplementation(IRepository<Turma> repository, ID2lRepository<CourseTemplateVO, CreateCourseTemplateVO, CourseTemplateInfoVO> d2LRepository, 
                                           ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lTypeUORepository, 
                                           ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lOURepository)
        {
            _repository = repository;
            _converter = new TurmaConverter();
            _d2lRepository = d2LRepository;
            _d2lTypeUORepository = d2lTypeUORepository;
            _d2lOURepository = d2lOURepository;           
        }

        // Method responsible for returning all people,
        public List<Turma> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Turma FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Turma Create(Turma dado)
        {            
            var dadoEntity = dado;
            dadoEntity = _repository.Create(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for updating one person
        public Turma Update(Turma dado)
        {
            var dadoEntity = dado;
            dadoEntity = _repository.Update(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public CourseTemplateVO OrgStructureTurma(long id)
        {
            string servico = "/coursetemplates/" + id.ToString();
            return _d2lRepository.Get(servico, null);
        }

        public List<OrgUnitVO> OrgStructureChildTurma(long id)
        {
            //busca o id do tipo filial
            List<OrgUnitTypeVO> typeUO = _d2lTypeUORepository.GetList("/outypes/", null);
            typeUO = typeUO.FindAll(delegate (OrgUnitTypeVO t) { return t.Code == "Course Template"; });
            string value = typeUO[0].Id.ToString();
            //busca filiais filhas do id
            List<ParamLista> param = new List<ParamLista> { new ParamLista { Atributo = "ouTypeId", Value = value } };
            string servico = "/orgstructure/" + id.ToString() + "/children/";
            return _d2lOURepository.GetList(servico, param);
        }

        public CourseTemplateVO CreateD2lTurma(CreateCourseTemplateVO dado)
        {
            string servico = "/coursetemplates/";
            return _d2lRepository.Post(servico, null, dado);
        }

        public CourseTemplateVO UpdateD2lTurma(long id, CourseTemplateInfoVO dado)
        {
            string servico = "/coursetemplates/" + id.ToString();
            return _d2lRepository.Put(servico, null, dado);
        }
    }
}

