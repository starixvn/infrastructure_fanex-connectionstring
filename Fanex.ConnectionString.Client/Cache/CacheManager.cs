// --------------------------------------------------------------------------
// <copyright file="CacheManager.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.16">Created</change>
// </history>

namespace Fanex.ConnectionString.Client.Cache
{
    using System.Runtime.Caching;

    /// <summary>
    /// The cache manager class.
    /// </summary>
    public class CacheManager
    {
        private static ObjectCache _cache;

        private static CacheManager _cacheManager;

        public CacheManager()
        {
            _cache = MemoryCache.Default;
        }

        public static CacheManager Cache
        {
            get
            {
                if (_cacheManager == null)
                {
                    _cacheManager = new CacheManager();
                }

                return _cacheManager;
            }
        }

        public void Set(string key, object value)
        {
            _cache.Set(key, value, null);
        }

        public T Get<T>(string key)
        {
            T value = (T)_cache.Get(key);

            return value;
        }
    }
}
