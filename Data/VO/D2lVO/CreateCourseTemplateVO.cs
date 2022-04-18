namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class CreateCourseTemplateVO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long[] ParentOrgUnitIds { get; set; }
    }
}
