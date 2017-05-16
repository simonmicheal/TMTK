using System;
using System.Collections.Generic;

namespace TMTK.Services
{
	public static class Globals
	{
#if DEBUG
		public const string kAppHostURL = @"https://tmtk.pioneeringprogrammers.net/";
		//public const string kAppHostURL = @"http://tmtkdev.azurewebsites.net/";
#else
		public const string kAppHostURL = @"https://tmtk.pioneeringprogrammers.net/";
#endif
		public const string kEnterpriseLogin = (kAppHostURL + @"api/Login/");

		//Command
		public const string kClientCommand = (kAppHostURL + @"/api/SendClientCommandToServer");
		public const string loginpackage = "{ \"UserName\": \"{0}\",\"Password\": \"{0}\" }";
	}
}
                            