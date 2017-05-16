using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMTK.Models;

namespace TMTK.Services
{
	public class AuthenticationService : BaseService
	{
		public async Task<ContactRoot> login(LoginModel login)
		{
			CancellationToken token;

			try
			{
				StringContent stringContent = SerializeObject(login);
				
				var data = await RestService.SendAsync(stringContent,Globals.kEnterpriseLogin, token);

				if (data.IsSuccessStatusCode)
				{
					var res = await data.Content.ReadAsStringAsync();
					var t = JsonConvert.DeserializeObject<ContactRoot>(res);
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
