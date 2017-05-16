using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TMTK.Services
{
	public class BaseService
	{
		private RestClient _restClient;

		public RestClient RestService
		{
			get
			{
				if (_restClient == null)
				{
					_restClient = new RestClient();
				}

				return _restClient;
			}
		}

		public StringContent SerializeObject<T>(T model)
		{
			try
			{
				var s = JsonConvert.SerializeObject(model).ToString();

				StringContent stringContent = new StringContent(
					s,
					Encoding.UTF8,
				"application/json");
				return stringContent;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
