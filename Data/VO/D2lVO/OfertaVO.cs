using System;

namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class OfertaVO
    {
        public long Identifier { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool CanSelfRegister { get; set; }
        public OfertaDescriptionVO Description { get; set; }
        public string Path { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OfertaSubItemVO CourseTemplate { get; set; }
        public OfertaSubItemVO Semester { get; set; }
        public OfertaSubItemVO Department { get; set; }
    }
}
