using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;
using System.Linq;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class SpeakersTests
	{

		[Test]
		public async void GetSpeakersForEvent_Test()
		{
			APIService srv = new APIService();
			SpeakerModel model = new SpeakerModel();
			EventModel evtmodel = new EventModel();

			evtmodel.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
			evtmodel.CommandModel.Action = "GetOpenEvents";

			var res = await srv.GetEvents(evtmodel.CommandModel);

			if (res.Status == "OK" && res.Data != null)
			{
				Dictionary<string, string> p = new Dictionary<string, string>();
				p.Add("eventId", string.Format("'{0}'", res.Data.FirstOrDefault().Id));

				model.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
				model.CommandModel.ServiceName = "Speaker";
				model.CommandModel.Action = "GetSpeakersForEvent";
				model.CommandModel.Parameters = p;

				var r = await srv.GetSpeakersForEvent(model.CommandModel);

				Assert.True(r.Status == "OK" && r.Data != null);
			}
			else
			{
				Assert.IsTrue(false);
			}
		}

		[Test]
		public async void GetSpeakerForEvent_Test()
		{
			APIService srv = new APIService();
			SponsorModel model = new SponsorModel();
			EventModel evtmodel = new EventModel();

			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("id", string.Format("'{0}'", "5ef950ed-db6a-4592-a53a-8c91b44910bf"));

			model.CommandModel.SessionToken = "bd95daab54ea3f8039b2521c50590b6e98d18bb7ad1242bee64216853bf2f6d2";
			model.CommandModel.ServiceName = "Speaker";
			model.CommandModel.Action = "GetById";
			model.CommandModel.Parameters = p;

			var r = await srv.GetSpeakerById(model.CommandModel);

			Assert.True(r.Status == "OK" && r != null);
		}
	}
}