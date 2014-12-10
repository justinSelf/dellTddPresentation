namespace ContentFetcher
{
    public interface IServiceProxy
    {
        string GetContent();
    }

    public class ServiceProxy : IServiceProxy
    {
        public string GetContent()
        {
            return "This is the content returned by the service proxy";
        }
    }
}