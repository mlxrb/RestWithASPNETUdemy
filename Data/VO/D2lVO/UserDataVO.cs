namespace RestWithASPNETUdemy.Data.VO.D2lVO
{
	public class UserDataVO
	{
		public long OrgId { get; set; }
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string ExternalEmail { get; set; }
		public string OrgDefinedId { get; set; }
		public string UniqueIdentifier { get; set; }
		public string Activation { get; set; }
		public string LastAccessedDate { get; set; }
		public string Pronouns { get; set; }
	}
}