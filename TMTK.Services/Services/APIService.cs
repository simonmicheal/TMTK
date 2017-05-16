using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMTK.Models;

namespace TMTK.Services
{
	public class APIService : BaseService
	{
		#region Refresh
		public async Task<ContactsResults> RefreshFromServer(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<ContactsResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}
		#endregion

		public async Task<EventResults> GetEvents(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<EventResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<ScheduleResults> GetSchedulesForEvent(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<ScheduleResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<SessionResults> GetSessionsForSchedule(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<SessionResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<SpeakersResults> GetSpeakersForEvent(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<SpeakersResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<SponsorsResults> GetSponsorsForEvent(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<SponsorsResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<SponsorResults> GetSponsorById(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<SponsorResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<SpeakerResults> GetSpeakerById(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<SpeakerResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<ContestResults> GetContestsForEvent(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<ContestResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public async Task<FinalistResults> GetFinalistsForContest(CommandModel model)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(model);

				var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<FinalistResults>(res);
					return t;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}
        public async Task<ContestVoteResults> GetContestVoteForContact(CommandModel model)
        {
            CancellationToken token;

            try
            {
                StringContent stringContent = SerializeObject(model);

                var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

                if (data.IsSuccessStatusCode)
                {
                    var res = await data.Content.ReadAsStringAsync();
                    var t = JsonConvert.DeserializeObject<ContestVoteResults>(res);
                    return t;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
        public async Task<ContestVoteResults> SaveContestVote(CommandModel model)
        {
            CancellationToken token;

            try
            {
                StringContent stringContent = SerializeObject(model);

                var data = await RestService.SendAsync(stringContent, Globals.kClientCommand, token);

                if (data.IsSuccessStatusCode)
                {
                    var res = await data.Content.ReadAsStringAsync();
                    var t = JsonConvert.DeserializeObject<ContestVoteResults>(res);
                    return t;
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
