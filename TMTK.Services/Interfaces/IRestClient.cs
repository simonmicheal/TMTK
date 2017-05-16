using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TMTK.Services
{
	public interface IRestClient
	{
		Task<T> GetAsync<T>(string uri);
		Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken);
		Task<object> GetAsync(Type returnType, string uri, CancellationToken cancellationToken);

		Task<Stream> GetContentStream(string uri);
		Task<Stream> GetContentStream(string uri, CancellationToken cancellationToken);
		Task<byte[]> GetContentByte(string uri, CancellationToken cancellationToken);
	}
}
