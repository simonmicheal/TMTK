using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMTK.Models;
using TMTK.Services;
using System.Linq;
using Akavache;
using System.Reactive.Linq;
using System.Collections.ObjectModel;

namespace TMTK
{
	public class SchedulesDefinition : ViewModelBase
	{
		private static async Task<EventResults> GetEvents()
		{
			APIService srv = new APIService();
			EventModel model = new EventModel();
			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.Action = "GetOpenEvents";

			EventResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedEventsPromise = cache.GetAndFetchLatest(
				"events",
				() => srv.GetEvents(model.CommandModel),
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
				}).FirstOrDefaultAsync();

			cachedEventsPromise.Subscribe(subscribedEvents =>
			{
				result = subscribedEvents;
			});

			result = await cachedEventsPromise.FirstOrDefaultAsync();
			return result;
		}

		private static async Task<ScheduleResults> GetSchedules(string eventID)
		{
			APIService srv = new APIService();
			ScheduleModel model = new ScheduleModel();
			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("eventId", string.Format("'{0}'", eventID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Schedule";
			model.CommandModel.Action = "GetSchedulesForEvent";
			model.CommandModel.Parameters = p;

			ScheduleResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSchedulesPromise = cache.GetAndFetchLatest(
				"schedules",
				() => srv.GetSchedulesForEvent(model.CommandModel),
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
				});

			cachedSchedulesPromise.Subscribe(subscribedSchedules =>
			{
				result = subscribedSchedules;
			});

			result = await cachedSchedulesPromise.FirstOrDefaultAsync();
			return result;
		}

		private static async Task<SessionResults> GetSessions(string scheduleID)
		{
			APIService srv = new APIService();
			SessionModel model = new SessionModel();
			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("scheduleId", string.Format("'{0}'", scheduleID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Session";
			model.CommandModel.Action = "GetSessionsForSchedule";
			model.CommandModel.Parameters = p;

			SessionResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSessionPromise = cache.GetAndFetchLatest(
				scheduleID,
				() => srv.GetSessionsForSchedule(model.CommandModel),
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
				});

			cachedSessionPromise.Subscribe(subscribedSchedules =>
			{
				result = subscribedSchedules;
			});

			result = await cachedSessionPromise.FirstOrDefaultAsync();
			return result;
		}

		public static async Task<ObservableCollection<ScheduleGroup>> LoadSchedules()
		{
			ObservableCollection<ScheduleGroup> SchedulesGroupedByCategory = new ObservableCollection<ScheduleGroup>();

			try
			{
				//Get current session
				var _events = await GetEvents();

				if (_events.Status == "OK" && _events.Data != null)
				{
					var _schedules = await GetSchedules(_events.Data.FirstOrDefault().Id);

					if (_schedules.Status == "OK" && _schedules.Data != null)
					{
						var _orderedSchedules = _schedules.Data.OrderBy((arg) => arg.ScheduleDate);

						foreach (Schedule s in _orderedSchedules)
						{
							DateTimeOffset dto = DateTimeOffset.Parse(s.ScheduleDate);
							DateTime dtObject = dto.DateTime;

							var grp = new ScheduleGroup();
							grp.ScheduleDate = dtObject.ToString("dddd, MMMM d, yyyy");

							var _sessions = await GetSessions(s.Id);
							if (_sessions.Status == "OK")
							{
								foreach (Session ss in _sessions.Data.OrderBy(y => y.StartTime))
								{
									grp.Add(ss);
								}
							}

							SchedulesGroupedByCategory.Add(grp);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return SchedulesGroupedByCategory;
		}
	}
	public class ScheduleGroup : ObservableCollection<Session>
	{
		private string _scheduleDate;
		public string ScheduleDate
		{
			get
			{
				return _scheduleDate;
			}
			set
			{
				_scheduleDate = value;
			}
		}
	}
}
