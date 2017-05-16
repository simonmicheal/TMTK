using System;
using System.Threading.Tasks;
using Akavache;
using TMTK.Models;
using TMTK.Services;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Collections.ObjectModel;

namespace TMTK
{
	public class SpeakersDefinition : ViewModelBase
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

		private static async Task<SpeakersResults> GetSpeakers(string eventID)
		{
			APIService srv = new APIService();
			SpeakerModel model = new SpeakerModel();
			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("eventId", string.Format("'{0}'", eventID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Speaker";
			model.CommandModel.Action = "GetSpeakersForEvent";
			model.CommandModel.Parameters = p;

			SpeakersResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSpeakersPromise = cache.GetAndFetchLatest(
			"speakers",
			() => srv.GetSpeakersForEvent(model.CommandModel),
			offset =>
			{
				TimeSpan elapsed = DateTimeOffset.Now - offset;
				return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
			});

			cachedSpeakersPromise.Subscribe(subscribedSpeakers =>
			{
				result = subscribedSpeakers;
			});

			result = await cachedSpeakersPromise.FirstOrDefaultAsync();
			return result;
		}

		public static async Task<ObservableCollection<Speakers>> LoadSpeakers()
		{
			ObservableCollection<Speakers> SpeakersCollection = new ObservableCollection<Speakers>();

			try
			{
				//Get current session
				var _events = await GetEvents();

				if (_events.Status == "OK" && _events.Data != null)
				{
					var _speakers = await GetSpeakers(_events.Data.FirstOrDefault().Id);

					if (_speakers.Status == "OK" && _speakers.Data != null)
					{
						foreach (Speakers s in _speakers.Data)
						{
							SpeakersCollection.Add(s);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return SpeakersCollection;
		}

		private static async Task<SpeakerResults> GetSpeakerById(string speakerID)
		{
			APIService srv = new APIService();
			SessionModel model = new SessionModel();

			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("id", string.Format("'{0}'", speakerID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Speaker";
			model.CommandModel.Action = "GetById";
			model.CommandModel.Parameters = p;

			SpeakerResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSpeakerPromise = cache.GetAndFetchLatest(
				speakerID,
				() => srv.GetSpeakerById(model.CommandModel),
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
				});

			cachedSpeakerPromise.Subscribe(subscribedSpeaker =>
			{
				result = subscribedSpeaker;
			});

			result = await cachedSpeakerPromise.FirstOrDefaultAsync();
			return result;
		}

		public static async Task<Speakers> LoadSpeaker(string speakerID)
		{
			try
			{
				SpeakerResults _speakers = await GetSpeakerById(speakerID);

				if (_speakers.Status == "OK" && _speakers.Data != null)
				{

					return _speakers.Data;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}
	}
}
