using Microsoft.Extensions.Caching.Memory;

namespace thewhiskeystudy.Managers
{
    public class BaseManager
    {
        protected IMemoryCache cache;

        public BaseManager(IMemoryCache cache)
        {
            this.cache = cache;
        }
    }
}