using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("log_filial")]
    public class Filial : BaseEntity
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
         
        [Column("custom_code")]
        public string CustomCode { get; set; }

        [Column("system")]
        public string System { get; set; }

        [Column("moment_exec")]
        public DateTime MomentExec { get; set; }
    }

}
