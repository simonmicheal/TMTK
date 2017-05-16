
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class AuthenticationTest
	{
		[Test]
		public void Login_Test()
		{
			AuthenticationService srv = new AuthenticationService();

			LoginModel l = new LoginModel() { UserName = "simonsmith", Password = "mexico1234" };

			var task = Task.Run(() => srv.login(l));
			var f = task.Result;

			Assert.True(f.Status == "OK" && f.Contact != null);
		}
	}
}
