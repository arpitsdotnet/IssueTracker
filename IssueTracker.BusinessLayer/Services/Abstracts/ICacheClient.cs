using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface ICacheClient
    {
        ResultList<T> Get<T>(string key);
        void Set<T>(string key, ResultList<T> resultList);
    }
}