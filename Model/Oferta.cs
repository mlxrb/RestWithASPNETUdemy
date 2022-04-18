using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("log_oferta")]
    public class Oferta : BaseEntity
    {
        [Column("identifier_ava")]
        public long IdentifierAva { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("action")]
        public string Action { get; set; }

        [Column("code")]
        public string Code { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("endDate")]
        public DateTime EndDate { get; set; }

        [Column("template_code")]
        public long TemplateCode { get; set; }
         
        [Column("semester_code")]
        public long SemesterCode { get; set; }        

        [Column("custom_code")]
        public long CustomCode { get; set; }

        [Column("system")]
        public string System { get; set; }

        [Column("moment_exec")]
        public DateTime MomentExec { get; set; }
    }

}
