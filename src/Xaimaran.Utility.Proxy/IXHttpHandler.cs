namespace Xaimaran.Utility.Proxy;

public interface IXHttpHandler
{
    HttpClientHandler Handler { get; }
}

public class XHttpHandler : IXHttpHandler
{
    private XHttpHandler(HttpClientHandler handler)
    {
        Handler = handler;
    }

    public static XHttpHandler Create(HttpClientHandler handler)
        => new(handler);

    public HttpClientHandler Handler { get;  }
}