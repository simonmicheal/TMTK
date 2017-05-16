using System;
namespace TMTK.Models
{
	public class Contact : BaseModel
	{
		public int Contact_MNID { get; set; }
		public object Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string CompanyName { get; set; }
		public string ProfilePicURL { get; set; }
		public string ProfilePic { get; set; }
		public string SessionToken { get; set; }
		public string HomeMenu { get; set; }
		public string Status { get; set; }
		public int Id { get; set; }
	}

	public class ContactRoot
	{
		public string Status { get; set; }
		public Contact Contact { get; set; }
		public string ErrorMessage { get; set; }
	}
}


