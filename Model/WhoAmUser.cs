using RestWithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    public class WhoAmUser : BaseEntity
	{
		[Key]
		[Column("id")]
		public string Identifier { get; set; }
		[Column("fist_name")]
		public string FirstName { get; set; }
		[Column("last_name")]
		public string LastName { get; set; }
		[Column("uniquename")]
		public string UniqueName { get; set; }
		[Column("profile_identifier")]
		public string ProfileIdentifier { get; set; }

	}
}
