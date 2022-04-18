using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class CursoBusinessImplementation : ICursoBusiness
    {

        private readonly IRepository<Curso> _repository;
        private readonly ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lRepository;
        private readonly ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lTypeUORepository;

        private readonly CursoConverter _converter;

        public CursoBusinessImplementation(IRepository<Curso> repository, ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2LRepository, ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lTypeUORepository)
        {
            _repository = repository;
            _converter = new CursoConverter();
            _d2lRepository = d2LRepository;
            _d2lTypeUORepository = d2lTypeUORepository;
        }

        // Method responsible for returning all people,
        public List<Curso> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Curso FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Curso Create(Curso dado)
        {            
            var dadoEntity = dado;
            dadoEntity = _repository.Create(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for updating one person
        public Curso Update(Curso dado)
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

        public OrgUnitVO OrgStructureCurso(long id)
        {
            string servico = "/orgstructure/"+id.ToString();
            return _d2lRepository.Get(servico, null);
        }

        public List<OrgUnitVO> OrgStructureChildCurso(long id)
        {
            //busca o id do tipo filial
            List<OrgUnitTypeVO> typeUO = _d2lTypeUORepository.GetList("/outypes/", null);
            typeUO = typeUO.FindAll(delegate (OrgUnitTypeVO t) { return t.Code == "Cursos"; });
            string value = typeUO[0].Id.ToString();
            //busca filiais filhas do id
            List<ParamLista> param = new List<ParamLista> { new ParamLista { Atributo = "ouTypeId", Value = value } };
            string servico = "/orgstructure/" + id.ToString() + "/children/";
            return _d2lRepository.GetList(servico, param);
        }

        public OrgUnitVO CreateD2lCurso(OrgUnitCreateDataVO filial)
        {
            string servico = "/orgstructure/";
            return _d2lRepository.Post(servico, null, filial);
        }

        public OrgUnitVO UpdateD2lCurso(long id, OrgUnitPropertiesVO filial)
        {
            string servico = "/orgstructure/" + id.ToString();
            return _d2lRepository.Put(servico, null, filial);
        }
    }
}

