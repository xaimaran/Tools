using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xaimaran.Utility.Proxy.Options;

namespace Xaimaran.Utility.Proxy
{
    public static class AddSocks5Service
    {
        /// <summary>
        /// Add Socks5 Proxy HttpHandler
        /// </summary>
        public static IServiceCollection InjectSocks5(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options =
                configuration
                    .GetSection(Socks5Options.SectionName)
                    .Get<Socks5Options>();

            var handler =
                HttpClientHandlerWithProxyBuilder
                    .Config
                    .Set(
                        new Uri(
                            options.Address
                        ),
                        new NetworkCredential(
                            options.User,
                            options.Password
                        )
                    )
                    .Build;

            services
                .AddSingleton<IXHttpHandler>
                (
                    XHttpHandler.Create(handler)
                );

            return services;
        }

    }
}