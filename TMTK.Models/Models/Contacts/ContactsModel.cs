using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class ContactsModel : BaseModel
	{
		public ContactsModel()
		{
			CommandModel.Area = "Account";
			CommandModel.ServiceName = "Contact";
		}
	}

	public class ContactsResults
	{
		public List<object> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}