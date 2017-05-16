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
	public class ScheduleTests
	{

		[Test]
		public async void GetScheduleForEvent_Test()
		{
			APIService srv = new APIService();
			ScheduleModel model = new ScheduleModel();
			EventModel evtmodel = new EventModel();

			evtmodel.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
			evtmodel.CommandModel.Action = "GetOpenEvents";

			var res = await srv.GetEvents(evtmodel.CommandModel);

			if (res.Status == "OK" && res.Data != null)
			{
				Dictionary<string, string> p = new Dictionary<string, string>();
				p.Add("eventId",string.Format("'{0}'", res.Data.FirstOrDefault().Id));

				model.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
				model.CommandModel.ServiceName = "Schedule";
				model.CommandModel.Action = "GetSchedulesForEvent";
				model.CommandModel.Parameters = p;

				var r = await srv.GetSessionsForSchedule(model.CommandModel);

				Assert.True(r.Status == "OK" && r.Data != null);
			}
			else
			{
				Assert.IsTrue(false);
			}
		}
	}
}
