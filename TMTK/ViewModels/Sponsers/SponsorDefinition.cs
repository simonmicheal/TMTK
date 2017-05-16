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
	public class SponsorDefinition : ViewModelBase
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

		private static async Task<SponsorsResults> GetSponsors(string eventID)
		{
			APIService srv = new APIService();
			SponsorModel model = new SponsorModel();
			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("eventId", string.Format("'{0}'", eventID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Sponsor";
			model.CommandModel.Action = "GetSponsorsForEvent";
			model.CommandModel.Parameters = p;

			SponsorsResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSponsorsPromise = cache.GetAndFetchLatest(
			"sponsors",
			() => srv.GetSponsorsForEvent(model.CommandModel),
			offset =>
			{
				TimeSpan elapsed = DateTimeOffset.Now - offset;
				return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
			});

			cachedSponsorsPromise.Subscribe(subscribedSponsors =>
			{
				result = subscribedSponsors;
			});

			result = await cachedSponsorsPromise.FirstOrDefaultAsync();
			return result;
		}

		private static async Task<SponsorResults> GetSponsor(string sponsorID)
		{
			APIService srv = new APIService();
			SponsorModel model = new SponsorModel();
			Dictionary<string, string> p = new Dictionary<string, string>();
			p.Add("id", string.Format("'{0}'", sponsorID));

			model.CommandModel.SessionToken = await App.GetUsersSession();
			model.CommandModel.ServiceName = "Sponsor";
			model.CommandModel.Action = "GetById";
			model.CommandModel.Parameters = p;

			SponsorResults result = null;
			var cache = BlobCache.UserAccount;
			var cachedSponsorPromise = cache.GetAndFetchLatest(
			sponsorID,
						() => srv.GetSponsorById(model.CommandModel),
			offset =>
			{
				TimeSpan elapsed = DateTimeOffset.Now - offset;
				return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
			});

			cachedSponsorPromise.Subscribe(subscribedSponsor =>
			{
				result = subscribedSponsor;
			});

			result = await cachedSponsorPromise.FirstOrDefaultAsync();
			return result;
		}

		public static async Task<ObservableCollection<SponsorGroupingClass<string, Sponsor>>> LoadSponsors()
		{
			ObservableCollection<SponsorGroupingClass<string, Sponsor>> SponsorsCollection = null;

			try
			{
				//Get current session
				var _events = await GetEvents();

				if (_events.Status == "OK" && _events.Data != null)
				{
					var _sponsors = await GetSponsors(_events.Data.FirstOrDefault().Id);

					if (_sponsors.Status == "OK" && _sponsors.Data != null)
					{
						var sorted = from s in _sponsors.Data
						                         orderby s.DisplayOrder
												 group s by s.SponsorLevel into SponsorGroup
												 where SponsorGroup.Key != string.Empty
												 select new SponsorGroupingClass<string, Sponsor>(SponsorGroup.Key, SponsorGroup);

						var i = sorted.FirstOrDefault();
						var t = i[0];

						SponsorsCollection = new ObservableCollection<SponsorGroupingClass<string, Sponsor>>(sorted);
						SponsorsCollection[0].Add(t);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return SponsorsCollection;
		}


		public static async Task<Sponsor> LoadSponsor(string sponsorID)
		{
			try
			{

				var _sponsors = await GetSponsor(sponsorID);

				if (_sponsors.Status == "OK" && _sponsors.Data != null)
				{
					return _sponsors.Data;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}
	}

	public class SponsorGroupingClass<K, T> : ObservableCollection<T>
	{
		public K Key { get; private set; }

		public SponsorGroupingClass(K key, IEnumerable<T> items)
		{
			Key = key;
			foreach (var item in items)
			{
				Items.Add(item);
			}
		}
	}
}
