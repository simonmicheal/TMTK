using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TMTK.Services
{
	public abstract class RestClientBase : IRestClient
	{
		public abstract Task<object> GetAsync(Type returnType, string uri, CancellationToken cancellationToken);
		public abstract Task<Stream> GetContentStream(string uri, CancellationToken cancellationToken);
		public abstract Task<Byte[]> GetContentByte(string uri, CancellationToken cancellationToken);

		public Task<T> GetAsync<T>(string uri)
		{
			return this.GetAsync<T>(uri, CancellationToken.None);
		}

		public async Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken)
		{
			return (T)((object)(await this.GetAsync(typeof(T), uri, cancellationToken)));
		}

		public Task<Stream> GetContentStream(string uri)
		{
			return this.GetContentStream(uri, CancellationToken.None);
		}

		public Task<byte[]> GetContentByte(string uri)
		{
			return this.GetContentByte(uri, CancellationToken.None);
		}
	}
}
