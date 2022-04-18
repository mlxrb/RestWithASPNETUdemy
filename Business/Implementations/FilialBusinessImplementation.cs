using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class FilialBusinessImplementation : IFilialABusiness
    {

        private readonly IRepository<Filial> _repository;
        private readonly ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lRepository;
        private readonly ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lTypeUORepository;

        private readonly FilialConverter _converter;

        public FilialBusinessImplementation(IRepository<Filial> repository, ID2lRepository<OrgUnitVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2LRepository, ID2lRepository<OrgUnitTypeVO, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lTypeUORepository)
        {
            _repository = repository;
            _converter = new FilialConverter();
            _d2lRepository = d2LRepository;
            _d2lTypeUORepository = d2lTypeUORepository;
        }

        // Method responsible for returning all people,
        public List<Filial> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Filial FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Filial Create(Filial dado)
        {            
            var dadoEntity = dado;
            dadoEntity = _repository.Create(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for updating one person
        public Filial Update(Filial dado)
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

        public OrgUnitVO OrgStructure(long id)
        {
            string servico = "/orgstructure/"+id.ToString();
            return _d2lRepository.Get(servico, null);
        }

        public List<OrgUnitVO> OrgStructureChild(long id)
        {
            //busca o id do tipo filial
            List<OrgUnitTypeVO> typeUO = _d2lTypeUORepository.GetList("/outypes/", null);
            typeUO = typeUO.FindAll(delegate (OrgUnitTypeVO t) { return t.Code == "Filial"; });
            string value = typeUO[0].Id.ToString();
            //busca filiais filhas do id
            List<ParamLista> param = new List<ParamLista> { new ParamLista { Atributo = "ouTypeId", Value = value } };
            string servico = "/orgstructure/" + id.ToString() + "/children/";
            return _d2lRepository.GetList(servico, param);
        }

        public OrgUnitVO CreateD2l(OrgUnitCreateDataVO filial)
        {
            string servico = "/orgstructure/";
            return _d2lRepository.Post(servico, null, filial);
        }

        public OrgUnitVO UpdateD2l(long id, OrgUnitPropertiesVO filial)
        {
            string servico = "/orgstructure/" + id.ToString();
            return _d2lRepository.Put(servico, null, filial);
        }
    }
}

