using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xaimaran.Tools.Telegram.Options;
using Xaimaran.Tools.Telegram.Services;
using Xaimaran.Tools.Telegram.Services.Interfaces;

namespace Xaimaran.Tools.Telegram
{
    public static class AddTelegramDispatcherService
    {
        /// <summary>
        /// Add Telegram Bot Dispatcher
        /// </summary>
        public static IServiceCollection InjectTelegramDispatcher(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var option =
                configuration
                    .GetSection(TelegramBotOptions.SectionName)
                    .Get<TelegramBotOptions>();

            services.AddSingleton(option);

            services
                .AddSingleton<
                    ITelegramBotFactory,
                    TelegramBotFactory
                >();

            services
                .AddSingleton<
                    ITelegramDispatcher,
                    TelegramDispatcher
                >();

            return services;
        }

    }
}