using System.Net.Http;
using Telegram.Bot;
using Xaimaran.Tools.Telegram.Options;
using Xaimaran.Tools.Telegram.Services.Interfaces;
using Xaimaran.Utility.Proxy;

namespace Xaimaran.Tools.Telegram.Services;

public class TelegramBotFactory : ITelegramBotFactory
{
    private readonly TelegramBotOptions _options;
    private readonly IXHttpHandler _xHttpHandler;

    public TelegramBotFactory(
        TelegramBotOptions options,
        IXHttpHandler xHttpHandler = null
    )
    {
        _options = options.Value;
        _xHttpHandler = xHttpHandler;
    }


    public TelegramBotClient Initialize()
    {
        var httpClient =
            _xHttpHandler != null
                ? new HttpClient(_xHttpHandler.Handler)
                : new HttpClient();

        return new TelegramBotClient(
            _options.ApiToken,
            httpClient
        );
    }
}