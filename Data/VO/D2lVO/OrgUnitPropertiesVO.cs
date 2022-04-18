namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class OrgUnitPropertiesVO
    {
        public long Identifier { get; set; }       
        public string Name { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public OrgUnitTypeInfoVO Type { get; set; }
    }
}
