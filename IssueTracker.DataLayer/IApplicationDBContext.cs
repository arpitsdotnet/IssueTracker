using System.Collections.Generic;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.DataLayer
{
    public interface IApplicationDBContext
    {
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();

        ResultList<TResponse> LoadData<TResponse>(string storedProcedure, object parameters);
        ResultList<TResponse> LoadData<TRequest, TResponse>(string storedProcedure, TRequest parameters);
        ResultSingle<TResponse> SaveData<TResponse>(string storedProcedure, object parameters);
        ResultSingle<TResponse> SaveContinueData<TResponse>(string storedProcedure, object parameters);
    }
}