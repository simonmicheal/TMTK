using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMTK.Services
{
	public class RestClient : RestClientBase
	{
		private readonly HttpClient _http;

		public RestClient()
		{
			this._http = new HttpClientFactory().CreateHttpClient();
		}

		public async Task<HttpResponseMessage> SendAsync(StringContent payload, string uri, CancellationToken cancellationToken)
		{
			HttpResponseMessage result;

			try
			{

				result = await this._http.PostAsync(uri,payload);
			}
			catch (Exception ex)
			{
				RestClient.WrapAndThrowKnownExceptions(ex, "POST " + uri);
				throw ex;
			}

			return result;
		}

		public async Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken)
		{
			HttpRequestMessage request = HttpMessageRequestFactory.Create("GET", uri);
			HttpResponseMessage result;

			try
			{
				result = await this._http.SendAsync(request, cancellationToken);
			}
			catch (Exception ex)
			{
				RestClient.WrapAndThrowKnownExceptions(ex, "GET " + uri);
				throw;
			}

			return result;
		}

		public async Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken, string username, string password)
		{
			HttpRequestMessage request = HttpMessageRequestFactory.Create("POST", uri, username, password);
			HttpResponseMessage result;

			try
			{
				result = await this._http.SendAsync(request, cancellationToken);
			}
			catch (Exception ex)
			{
				RestClient.WrapAndThrowKnownExceptions(ex, "GET " + uri);
				throw;
			}

			return result;
		}

		public override async Task<Stream> GetContentStream(string uri, CancellationToken cancellationToken)
		{
			HttpResponseMessage httpResponseMessage = await this.GetAsync(uri, cancellationToken, "Simon", "Ironm@n2016");
			RestClient.EnsureSuccess(httpResponseMessage);
			return await httpResponseMessage.Content.ReadAsStreamAsync();
		}

		public override async Task<Byte[]> GetContentByte(string uri, CancellationToken cancellationToken)
		{
			HttpResponseMessage httpResponseMessage = await this.GetAsync(uri, cancellationToken, "Simon", "Ironm@n2016");
			RestClient.EnsureSuccess(httpResponseMessage);
			return await httpResponseMessage.Content.ReadAsByteArrayAsync();
		}

		public static void WrapAndThrowKnownExceptions(Exception ex, string operation)
		{
			if (ex is AggregateException)
			{
				RestClient.WrapAndThrowKnownExceptions((ex as AggregateException).Flatten().InnerException, operation);
			}
			if (ex is HttpRequestException || ex is WebException || ex is IOException || ex is TaskCanceledException || ex is TimeoutException)
			{
				throw ex;
			}
		}

		private static void EnsureSuccess(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				throw new APIErrorException(response);
			}
		}

		public override Task<object> GetAsync(Type returnType, string uri, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
