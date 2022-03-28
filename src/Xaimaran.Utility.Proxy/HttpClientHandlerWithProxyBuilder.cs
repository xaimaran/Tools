using System.Net;

namespace Xaimaran.Utility.Proxy
{
    public class HttpClientHandlerWithProxyBuilder
    {
        private readonly Uri _address;
        private readonly NetworkCredential _networkCredential;
        private static WebProxy? _webProxy;

        private HttpClientHandlerWithProxyBuilder(
            Uri address,
            NetworkCredential networkCredential
            )
        {
            _address = address;
            _networkCredential = networkCredential;
        }

        private WebProxy CreateWebProxy()
        {
            WebProxy proxy = new()
            {
                Address = _address,
                Credentials = _networkCredential,
            };

            return proxy;
        }

        private HttpClientHandler Build()
        {
            HttpClientHandler handler = new()
            {
                Proxy = _webProxy
            };

            return handler;
        }

        public class Config
        {
            readonly HttpClientHandlerWithProxyBuilder _instance;
            public Config(
                Uri address,
                NetworkCredential networkCredential
            )
            {
                _instance = new HttpClientHandlerWithProxyBuilder(
                    address,
                    networkCredential
                );

                _webProxy = _instance.CreateWebProxy();
            }

            public static Config Set(
                Uri address,
                NetworkCredential networkCredential
            ) =>
                new (address, networkCredential);

            public HttpClientHandler Build => _instance.Build();
        }
    }
}