using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Busness.Implementations
{
    public class WhoAmUserBusinessImplementaiton : IWhoAmUserBusiness
    {

        private ID2lRepository<WhoAmUser, OrgUnitCreateDataVO, OrgUnitPropertiesVO> _d2lRepository;
        private readonly WhoAmUserConverter _converter;


        public WhoAmUserBusinessImplementaiton(ID2lRepository<WhoAmUser, OrgUnitCreateDataVO, OrgUnitPropertiesVO> d2lRepository)
        {
            _d2lRepository = d2lRepository;
            _converter = new WhoAmUserConverter();
        }

        public WhoAmUserVO ExecuteService(string servico)
        {
            return _converter.Parse(_d2lRepository.Get(servico, null));
             
        }

    }   
}
