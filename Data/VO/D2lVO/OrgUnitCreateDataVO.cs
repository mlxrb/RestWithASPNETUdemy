namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class OrgUnitCreateDataVO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long[] Parents { get; set; }
    }
}
