using System;
using System.Runtime.Caching;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Services.CacheService
{
    public class CacheClient : ICacheClient
    {
        private readonly MemoryCache _cache;

        public CacheClient()
        {
        }

        public ResultList<T> Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, ResultList<T> resultList)
        {
            //var cacheEntryOptions = new MemoryCacheEntryOptions
        }
    }
}
