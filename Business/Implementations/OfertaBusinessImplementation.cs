using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class OfertaBusinessImplementation : IOfertaBusiness
    {

        private readonly IRepository<Oferta> _repository;
        private readonly ID2lRepository<OfertaVO, OfertaVOPost, OfertaVO> _d2lRepository;
        private readonly ID2lRepository<OrgUnitVO, OfertaVOPost, OfertaVO> _d2lRepositoryOU;
        private readonly ID2lRepository<OrgUnitTypeVO, OfertaVOPost, OfertaVO> _d2lTypeUORepository;

       

        public OfertaBusinessImplementation(IRepository<Oferta> repository, 
            ID2lRepository<OfertaVO, OfertaVOPost, OfertaVO> d2LRepository, 
            ID2lRepository<OrgUnitTypeVO, OfertaVOPost, OfertaVO> d2lTypeUORepository,
            ID2lRepository<OrgUnitVO, OfertaVOPost, OfertaVO> d2LRepositoryOU)
        {
            _repository = repository;            
            _d2lRepository = d2LRepository;
            _d2lRepositoryOU = d2LRepositoryOU;
            _d2lTypeUORepository = d2lTypeUORepository;
        }

        // Method responsible for returning all people,
        public List<Oferta> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Oferta FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Oferta Create(Oferta dado)
        {            
            var dadoEntity = dado;
            dadoEntity = _repository.Create(dadoEntity);
            return dadoEntity;
        }

        // Method responsible for updating one person
        public Oferta Update(Oferta dado)
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

        public OfertaVO getOfertas(long id)
        {
            string servico = "/orgstructure/"+id.ToString();
            return _d2lRepository.Get(servico, null);
        }

        public List<OrgUnitVO> OrgStructureAncestorsOferta(long id)
        {
            //busca o id do tipo filial
            List<OrgUnitTypeVO> typeUO = _d2lTypeUORepository.GetList("/outypes/", null);
            typeUO = typeUO.FindAll(delegate (OrgUnitTypeVO t) { return t.Code == "Course Offering"; });
            string value = typeUO[0].Id.ToString();
            //busca filiais filhas do id
            List<ParamLista> param = new List<ParamLista> { new ParamLista { Atributo = "ouTypeId", Value = value } };
            string servico = "/orgstructure/" + id.ToString() + "/ancestors/";
            return _d2lRepositoryOU.GetList(servico, param);
        }

        public OfertaVO CreateD2lOferta(OfertaVOPost filial)
        {
            string servico = "/courses/";
            return _d2lRepository.Post(servico, null, filial);
        }

        public OfertaVO UpdateD2lOferta(long id, OfertaVO filial)
        {
            string servico = "/courses/" + id.ToString();
            return _d2lRepository.Put(servico, null, filial);
        }
    }
}

