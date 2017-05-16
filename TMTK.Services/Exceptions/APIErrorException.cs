using System;
using System.Net.Http;

namespace TMTK.Services
{
	public class APIErrorException : Exception
	{
		public string ErrorResponse
		{
			get;
			private set;
		}

		public APIErrorException(HttpResponseMessage response)
		{
			this.ErrorResponse = response.Content.ReadAsStringAsync().Result;
		}
	}
}
