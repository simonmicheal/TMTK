using System;
using System.Net.Http;

namespace TMTK.Services
{
	public interface IHttpClientHandlerFactory
	{
		HttpClientHandler GetHttpClientHandler();
	}
}
