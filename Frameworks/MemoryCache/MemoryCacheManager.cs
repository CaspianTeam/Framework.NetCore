using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

namespace CaspianTeam.Framework.NetCore.Frameworks.MemoryCache
{
    public interface IMemoryCacheManager: IMemoryCache
    {
        void RemoveByPattern(string pattern);
    }

    public class MemoryCacheManager : IMemoryCacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Dispose()
        {
            _memoryCache?.Dispose();
        }

        public bool TryGetValue(object key, out object value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public ICacheEntry CreateEntry(object key)
        {
            return _memoryCache.CreateEntry(key);
        }

        public void Remove(object key)
        {
            lock (_memoryCache)
            {
                _memoryCache.Remove(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            var keysToRemove = GetKeysByPattern(pattern);

            lock (_memoryCache)
            {
                // lock atomic operation
                foreach (var key in keysToRemove)
                {
                    _memoryCache.Remove(key);
                }
            }
        }

        private List<string> GetKeysByPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException(nameof(pattern));

            var field = typeof(Microsoft.Extensions.Caching.Memory.MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(_memoryCache) as ICollection;
            var keys = new List<string>();
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    keys.Add(val.ToString());
                }
            }

            if (pattern == "*")
            {
                return keys;
            }

            return keys.Where(x => x.StartsWith(pattern, StringComparison.OrdinalIgnoreCase)).ToList();
        }


    }
}
