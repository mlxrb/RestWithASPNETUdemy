using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class WhoAmUserConverter : IParser<WhoAmUserVO, WhoAmUser>, IParser<WhoAmUser, WhoAmUserVO>
    {
        public WhoAmUser Parse(WhoAmUserVO origin)
        {
            if (origin == null) return null;
            return new WhoAmUser
            {
                Identifier = origin.Identifier,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                UniqueName = origin.UniqueName,
                ProfileIdentifier = origin.ProfileIdentifier
            };
        }

        public WhoAmUserVO Parse(WhoAmUser origin)
        {
            if (origin == null) return null;
            return new WhoAmUserVO
            {
                Identifier = origin.Identifier,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                UniqueName = origin.UniqueName,
                ProfileIdentifier = origin.ProfileIdentifier
            };
        }

        public List<WhoAmUser> Parse(List<WhoAmUserVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }


        public List<WhoAmUserVO> Parse(List<WhoAmUser> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

     }
}
