using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO.D2lVO
{

    public class OrgUnitVO : ISupportsHyperMedia
    {        
        public long Identifier { get; set; }               
        public string Name { get; set; }        
        public string Code { get; set; }        
        public OrgUnitTypeInfoVO Type { get; set; }           
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }

}
