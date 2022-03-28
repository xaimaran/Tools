using Telegram.Bot;

namespace Xaimaran.Tools.Telegram.Services.Interfaces;

public interface ITelegramBotFactory
{
    TelegramBotClient Initialize();
}