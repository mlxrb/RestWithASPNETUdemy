using System;

namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
    public class OfertaVOPost
    {        
        public string Name { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public long CourseTemplateId { get; set; }
        public long SemesterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long LocaleId { get; set; }
        public bool ForceLocale { get; set; }
        public bool ShowAddressBook { get; set; }
        public OfertaDescriptionVO Description { get; set; }
        public bool CanSelfRegister { get; set; }
    }
}
