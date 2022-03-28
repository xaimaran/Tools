using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Xaimaran.Tools.Telegram.Services.Interfaces;

public interface ITelegramDispatcher
{
    Task<Message> ToChannel(
        string chatId,
        string text);
}