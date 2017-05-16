using System;
using System.Net.Http;
using ModernHttpClient;

namespace TMTK.Services
{
	internal class HttpClientFactory
	{
		public TimeSpan DefaultTimout = TimeSpan.FromSeconds(30.0);

		public HttpClient CreateHttpClient()
		{
			HttpClient httpClient = new HttpClient(new NativeMessageHandler());
			HttpClientFactory.Prepare(httpClient, this.DefaultTimout);
			return httpClient;
		}

		private static void Prepare(HttpClient http, TimeSpan timeout)
		{
			http.Timeout = timeout;
			http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
