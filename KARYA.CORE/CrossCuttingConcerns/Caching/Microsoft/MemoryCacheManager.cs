using KARYA.CORE.CrossCuttingConcerns.Cashhing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;

namespace KARYA.CORE.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;

        public void Add(string key, object data, int cacheTime=60)
        {
            if (data == null) return;

            CacheItemPolicy cacheItemPolicy = new()
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key, data), cacheItemPolicy);
        }

        public void Clear(string key)
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Any(x => x.Key == key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline|RegexOptions.Compiled|RegexOptions.IgnoreCase);
            var removeCaches = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key);
            foreach (var key in removeCaches)
            {
                Remove(key);
            }
        }
    }
}
