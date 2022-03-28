using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Xaimaran.Tools.Telegram.Services.Interfaces;

namespace Xaimaran.Tools.Telegram.Services;

public class TelegramDispatcher : ITelegramDispatcher
{
    private readonly TelegramBotClient _bot;
    public TelegramDispatcher(ITelegramBotFactory botService)
    {
        _bot = botService.Initialize();
    }

    public async Task<Message> ToChannel(
        string chatId,
        string text) 
        =>
        await _bot
            .SendTextMessageAsync(
                chatId,
                text
            );
}