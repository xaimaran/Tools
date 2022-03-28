using Microsoft.Extensions.Options;

namespace Xaimaran.Utility.Proxy.Options
{
    public class Socks5Options  : IOptions<Socks5Options>
    {
        public const string SectionName = "Socks5";
        public string Address { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Socks5Options Value => this;
    }

}