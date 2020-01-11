using Microsoft.Extensions.Caching.Memory;

using thewhiskeystudy.lib.Enums;

namespace thewhiskeystudy.web.Managers
{
    public class BaseManager
    {
        private readonly IMemoryCache _cache;

        protected BaseManager()
        {
        }

        protected (bool isFound, T result) GetCachedItem<T>(CacheKeys key) where T : class => !_cache.TryGetValue(key, out T cacheEntry)
                ? (false, null)
                : (true, _cache.Get<T>(key));

        protected void AddCachedItem<T>(CacheKeys key, T obj)
        {
          //  var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.MaxValue);

          //  _cache.Set(key, obj, cacheEntryOptions);
        }
    }
}