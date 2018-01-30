using System;

using Microsoft.Extensions.Caching.Memory;

using thewhiskeystudy.lib.Enums;

namespace thewhiskeystudy.Managers
{
    public class BaseManager
    {
        protected IMemoryCache cache;

        public BaseManager(IMemoryCache cache)
        {
            this.cache = cache;
        }

        protected T GetCachedItem<T>(CacheKeys key)
        {
            if (!cache.TryGetValue(key, out T cacheEntry))
            {
                return default;
            }

            return cache.Get<T>(key);
        }

        protected void AddCachedItem<T>(CacheKeys key, T obj)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.MaxValue);

            cache.Set(key, obj, cacheEntryOptions);
        }
    }
}