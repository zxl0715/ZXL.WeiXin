
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace CNBlogs.Zzk.Domain.Entities
{
    public class DictionaryCacheManager<TK, TV>
    {
        private ObjectCache memoryCache;

        public DictionaryCacheManager() : this(null) { }
        public DictionaryCacheManager(string name)
        {

            memoryCache = new MemoryCache(string.Format("{0}-{1}-{2}", typeof(TK).Name, typeof(TV).Name, name));
        }

        public TV Get(TK key, Func<TV> getValue)
        {
            if (memoryCache.Contains(key.ToString()))
            {
                return (TV)memoryCache[key.ToString()];
            }
            else
            {
                var policy = new CacheItemPolicy();
                var v = getValue();
                object o = v;
                memoryCache.Set(key.ToString(), o, policy);
                return v;
            }
        }

        public TV Get(TK key, Func<TV> getValue, DateTimeOffset dateTimeOffset)
        {
            if (memoryCache.Contains(key.ToString()))
            {
                return (TV)memoryCache[key.ToString()];
            }
            else
            {
                var v = getValue();
                object o = v;
                memoryCache.Set(key.ToString(), o, dateTimeOffset);
                return v;
            }
        }

        public void Clear()
        {
            memoryCache.ToList().ForEach(kv => memoryCache.Remove(kv.Key));
        }
        public void Clear(TK key)
        {
            memoryCache.Remove(key.ToString());
        }

    }
}