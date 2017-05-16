using Akavache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using TMTK.Models;
using TMTK.Services;

namespace TMTK
{
    public class ContestsDefinition : ViewModelBase
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

        private static async Task<ContestResults> GetContest(string eventID)
        {
            APIService srv = new APIService();
            ContestModel model = new ContestModel();
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("eventId", string.Format("'{0}'", eventID));

            model.CommandModel.SessionToken = await App.GetUsersSession();
            model.CommandModel.ServiceName = "Contest";
            model.CommandModel.Action = "GetContestForEvent";
            model.CommandModel.Parameters = p;

            ContestResults result = null;
            var cache = BlobCache.UserAccount;
            var cachedContestsPromise = cache.GetAndFetchLatest(
                "contests",
                () => srv.GetContestsForEvent(model.CommandModel),
                offset =>
                {
                    TimeSpan elapsed = DateTimeOffset.Now - offset;
                    return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                });

            cachedContestsPromise.Subscribe(subscribedContests =>
            {
                result = subscribedContests;
            });

            result = await cachedContestsPromise.FirstOrDefaultAsync();
            return result;
        }

        private static async Task<FinalistResults> GetFinalists(string eventId)
        {
            APIService srv = new APIService();
            FinalistModel model = new FinalistModel();
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("eventId", string.Format("'{0}'", eventId));

            model.CommandModel.SessionToken = await App.GetUsersSession();
            model.CommandModel.ServiceName = "Finalist";
            model.CommandModel.Action = "GetFinalistsForEvent";
            model.CommandModel.Parameters = p;

            FinalistResults result = null;
            var cache = BlobCache.UserAccount;
            var cachedFinalistPromise = cache.GetAndFetchLatest(
                eventId,
                () => srv.GetFinalistsForContest(model.CommandModel),
                offset =>
                {
                    TimeSpan elapsed = DateTimeOffset.Now - offset;
                    return elapsed > new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                });

            cachedFinalistPromise.Subscribe(subscribedFinalists =>
            {
                result = subscribedFinalists;
            });

            result = await cachedFinalistPromise.FirstOrDefaultAsync();
            return result;
        }

        private static async Task<ContestVoteResults> GetContestVote(string contestId, string contactId)
        {
            APIService srv = new APIService();
            ContestVoteModel model = new ContestVoteModel();
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("contestId", string.Format("'{0}'", contestId));
            p.Add("contactId", string.Format("'{0}'", contactId));

            model.CommandModel.SessionToken = await App.GetUsersSession();
            model.CommandModel.ServiceName = "ContestVote";
            model.CommandModel.Action = "GetContestVoteForUser";
            model.CommandModel.Parameters = p;

						return await srv.GetContestVoteForContact(model.CommandModel);  
        }

        public static async Task<ContestVoteResults> SaveContestVote(ContestVote vote)
        {
            APIService srv = new APIService();
            ContestVoteModel model = new ContestVoteModel();
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("obj", JsonConvert.SerializeObject(vote));

            model.CommandModel.SessionToken = await App.GetUsersSession();
            model.CommandModel.ServiceName = "ContestVote";
            model.CommandModel.Action = "Save";
            model.CommandModel.Parameters = p;

						return await srv.SaveContestVote(model.CommandModel);
 
        }
        public static async Task<ObservableCollection<Finalist>> LoadContest()
        {
            ObservableCollection<Finalist> finalistsCollection = new ObservableCollection<Finalist>();

            try
            {
                //Get current event
                var _events = await GetEvents();

                if (_events.Status == "OK" && _events.Data != null)
                {
                    var _finalists = await GetFinalists(_events.Data.FirstOrDefault().Id);

                    if (_finalists.Status == "OK" && _finalists.Data != null)
                    {
                        foreach (Finalist f in _finalists.Data.OrderBy(f => f.DisplayOrder))
                        {
                            finalistsCollection.Add(f);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return finalistsCollection;
        }

        public static async Task<ContestVote> GetContestVoteForContact(string contestId)
        {
            Contact contact = await BlobCache.UserAccount.GetObject<Contact>("User").FirstOrDefaultAsync();
            var contestVote = await GetContestVote(contestId, contact.Contact_MNID.ToString());
            if (contestVote.Status == "OK" && contestVote.Data != null)
                return contestVote.Data;
            else
                return null;
        }
    }

}
