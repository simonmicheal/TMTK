using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;
using System.Linq;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class SponsorTests
	{

		[Test]
		public async void GetSponsorsForEvent_Test()
		{
			APIService srv = new APIService();
			SponsorModel model = new SponsorModel();
			EventModel evtmodel = new EventModel();

			evtmodel.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
			evtmodel.CommandModel.Action = "GetOpenEvents";

			var res = await srv.GetEvents(evtmodel.CommandModel);

			if (res.Status == "OK" && res.Data != null)
			{
				Dictionary<string, string> p = new Dictionary<string, string>();
				p.Add("eventId", string.Format("'{0}'", res.Data.FirstOrDefault().Id));

				model.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
				model.CommandModel.ServiceName = "Sponsor";
				model.CommandModel.Action = "GetSponsorsForEvent";
				model.CommandModel.Parameters = p;

				var r = await srv.GetSponsorsForEvent(model.CommandModel);

				Assert.True(r.Status == "OK" && r.Data != null);
			}
			else
			{
				Assert.IsTrue(false);
			}
		}

		[Test]
		public async void GetSponsorForEvent_Test()
		{
			APIService srv = new APIService();
			SponsorModel model = new SponsorModel();
			EventModel evtmodel = new EventModel();

			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("id", string.Format("'{0}'", "4b920877-6c43-45ad-a5bf-3d63a1e80171"));

			model.CommandModel.SessionToken = "bd95daab54ea3f8039b2521c50590b6e98d18bb7ad1242bee64216853bf2f6d2";
			model.CommandModel.ServiceName = "Sponsor";
			model.CommandModel.Action = "GetById";
			model.CommandModel.Parameters = p;

			var r = await srv.GetSponsorById(model.CommandModel);

			Assert.True(r.Status == "OK" && r != null);

		}
	}
}
