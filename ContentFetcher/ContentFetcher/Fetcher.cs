using System.Runtime.Remoting.Messaging;

namespace ContentFetcher
{
    public class Fetcher
    {
        private string cache = null;
        private readonly IServiceProxy serviceProxy;
        public Fetcher(IServiceProxy serviceProxy)
        {
            this.serviceProxy = serviceProxy;
        }

        public string Fetch()
        {
            if (cache == null) cache = serviceProxy.GetContent();
            return cache;
        }
    }
}