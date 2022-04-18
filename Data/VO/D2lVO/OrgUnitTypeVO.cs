namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class OrgUnitTypeVO
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public OrgUnitPermissionsVO Permissions { get; set; }
    }

}
