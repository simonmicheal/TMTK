using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TMTK.Services
{
	internal static class HttpMessageRequestFactory
	{
		public static HttpRequestMessage Create(string method, string address)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod(method), address);
			HttpMessageRequestFactory.AddCurrentClientTime(httpRequestMessage);
			return httpRequestMessage;
		}

		public static HttpRequestMessage Create(string method, string address, string username, string password)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod(method), address);
			HttpMessageRequestFactory.AddCurrentClientTime(httpRequestMessage);
			HttpMessageRequestFactory.AddAuthorization(httpRequestMessage, username, password);
			return httpRequestMessage;
		}

		private static void AddAuthorization(HttpRequestMessage message, string username, string password)
		{
			var authData = string.Format("{0}:{1}", username, password);
			var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
			var authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
			message.Headers.Authorization = authorization;
		}

		private static void AddCurrentClientTime(HttpRequestMessage message)
		{
			message.Headers.Add("X-Client-Current-Time", DateTime.UtcNow.ToString("yyyy-mm-dd-HH:mm:ss"));
		}
	}
}
