using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Contracts
{
    public interface IApplicationDBContext
    {
        Task OpenConnectionAsync();
        void CloseConnection();
        Task BeginTransactionAsync();
        void RollbackTransaction();
        void CommitTransaction();

        Task<ResultList<TResponse>> LoadDataAsync<TResponse>(string storedProcedure, object parameters);
        Task<ResultList<TResponse>> LoadDataAsync<TRequest, TResponse>(string storedProcedure, TRequest parameters);
        Task<ResultSingle<long>> SaveDataAsync(string storedProcedure, object parameters);
        Task<ResultSingle<TResponse>> SaveContinueDataAsync<TResponse>(string storedProcedure, object parameters);
    }
}