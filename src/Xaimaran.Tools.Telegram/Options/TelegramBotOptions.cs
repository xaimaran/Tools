using Microsoft.Extensions.Options;

namespace Xaimaran.Tools.Telegram.Options
{
    public class TelegramBotOptions : IOptions<TelegramBotOptions>
    {
        public const string SectionName = "TelegramBot";
        public string ApiToken { get; set; }
        public TelegramBotOptions Value => this;
    }

}