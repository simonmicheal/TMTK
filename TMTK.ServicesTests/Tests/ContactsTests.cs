using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class ContactsTests
	{
		[Test]
		public async void RefreshFromServer_Test()
		{
			APIService srv = new APIService();
			ContactsModel model = new ContactsModel();

			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("sessionToken", "''");

			model.CommandModel.SessionToken = "0d8f54e8fc0a1cd6ae1f091febd2251bf352beb508922f36d42c34dc8951c5a4";
			model.CommandModel.Action = "RefreshFromServer";
			model.CommandModel.Parameters = p;

			var r = await srv.RefreshFromServer(model.CommandModel);

			Assert.True(r.Status == "OK" && r.Data != null);
		}
	}
}
