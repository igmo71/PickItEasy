namespace PickItEasy.Integration.Proxy
{
    public interface IRequestHandler
    {
        Task<string> Handle<T>(T request);
    }
}
