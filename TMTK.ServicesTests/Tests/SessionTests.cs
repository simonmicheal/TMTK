
using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMTK.Models;
using TMTK.Services;
using System.Linq;

namespace TMTK.ServicesTests
{
	[TestFixture]
	public class SessionTests
	{
		[Test]
		public async void GetSessionsForSchedule_Test()
		{
			APIService srv = new APIService();
			ScheduleModel model = new ScheduleModel();
			EventModel evtmodel = new EventModel();
			SessionModel sModel = new SessionModel();

			evtmodel.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
			evtmodel.CommandModel.Action = "GetOpenEvents";

			var res = await srv.GetEvents(evtmodel.CommandModel);

			if (res.Status == "OK" && res.Data != null)
			{
				Dictionary<string, string> p = new Dictionary<string, string>();
				p.Add("eventId", string.Format("'{0}'", res.Data.FirstOrDefault().Id));

				model.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
				model.CommandModel.ServiceName = "Schedule";
				model.CommandModel.Action = "GetSchedulesForEvent";
				model.CommandModel.Parameters = p;

				var r = await srv.GetSchedulesForEvent(model.CommandModel);

				if (r.Status == "OK" && r.Data != null)
				{
					Dictionary<string, string> pp = new Dictionary<string, string>();
					pp.Add("scheduleId", string.Format("'{0}'", r.Data[0].Id));

					sModel.CommandModel.SessionToken = "bfc223c67931041556d324e25ee98cd0818dc6370486291d925127b1f5cd90ef";
					sModel.CommandModel.ServiceName = "Session";
					sModel.CommandModel.Action = "GetSessionsForSchedule";
					sModel.CommandModel.Parameters = pp;

					var rr = await srv.GetSessionsForSchedule(sModel.CommandModel);

					Assert.True(rr.Status == "OK" && rr.Data != null);

				}
			}
			else
			{
				Assert.IsTrue(false);
			}
		}
	}
}
