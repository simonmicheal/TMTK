
using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class EventsTests
	{
		[Test]
		public async void GetOpenEvents_Test()
		{
			APIService srv = new APIService();
			EventModel model = new EventModel();

			model.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
			model.CommandModel.Action = "GetOpenEvents";

			var r = await srv.GetEvents(model.CommandModel);

			Assert.True(r.Status == "OK" && r.Data != null);
		}
	}
}
