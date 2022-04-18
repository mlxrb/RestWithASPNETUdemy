using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PeriodoBusinessImplementation : IPeriodoBusiness
    {

        private readonly IRepository<Periodo> _repository;
        private readonly ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lRepository;
        private readonly ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lTypeUORepository;

        private readonly PeriodoConverter _converter;

        public PeriodoBusinessImplementation(IRepository<Periodo> repository, ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2LRepository, ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lTypeUORepository)
        {
            _repository = repository;
            _converter = new PeriodoConverter();
            _d2lRepository = d2LRepository;
            _d2lTypeUORepository = d2lTypeUORepository;
        }

        // Method responsible for returning all people,
        public List<Periodo> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Periodo FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Periodo Create(Periodo dado)
        {            
            var dadoEntity = dado;
            dadoEntity = _repository.Create(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for updating one person
        public Periodo Update(Periodo dado)
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

        public OrgUnitVO OrgStructurePeriodo(long id)
        {
            string servico = "/orgstructure/"+id.ToString();
            return _d2lRepository.Get(servico, null);
        }

        public List<OrgUnitVO> OrgStructureChildPeriodo(long id)
        {
            //busca o id do tipo filial
            List<OrgUnitTypeVO> typeUO = _d2lTypeUORepository.GetList("/outypes/", null);
            typeUO = typeUO.FindAll(delegate (OrgUnitTypeVO t) { return t.Code == "Período Letivo"; });
            string value = typeUO[0].Id.ToString();
            //busca filiais filhas do id
            List<ParamLista> param = new List<ParamLista> { new ParamLista { Atributo = "ouTypeId", Value = value } };
            string servico = "/orgstructure/" + id.ToString() + "/children/";
            return _d2lRepository.GetList(servico, param);
        }

        public OrgUnitVO CreateD2lPeriodo(OrgUnitCreateDataVO filial)
        {
            string servico = "/orgstructure/";
            return _d2lRepository.Post(servico, null, filial);
        }

        public OrgUnitVO UpdateD2lPeriodo(long id, OrgUnitPropertiesVO filial)
        {
            string servico = "/orgstructure/" + id.ToString();
            return _d2lRepository.Put(servico, null, filial);
        }
    }
}

