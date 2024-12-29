using System;
using IssueTracker.DataLayer;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;
using IssueTracker.ModelLayer.Issues.Requests;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class IssueController : CommonController
    {
        private readonly IApplicationDBContext _dBContext;
        public IssueController()
        {
            _dBContext = SQLDataAccess.Instance;
        }
        public ResultList<Issue> GetIssues(GetIssueRequest issueRequest)
        {
            var data = _dBContext.LoadData<GetIssueRequest, Issue>("spIssue_Get", issueRequest);

            return data;
        }
        public ResultSingle<Issue> SaveIssue(CreateIssueRequest issueRequest)
        {
            var data = _dBContext.SaveData<Int32>("spIssue_Save", issueRequest);

            return new ResultSingle<Issue> { IsSuccess = data.IsSuccess, Message = data.Message, Data = new Issue { IssueId = data.Data } };
        }
    }
}
