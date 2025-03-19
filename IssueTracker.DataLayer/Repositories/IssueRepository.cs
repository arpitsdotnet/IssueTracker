using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;
using IssueTracker.ModelLayer.Issues.Requests;

namespace IssueTracker.DataLayer.Repositories
{
    public interface IIssueRepository
    {
        ResultList<Issue> GetIssues(GetIssueRequest request);
        ResultSingle<Issue> SaveIssue(AddIssueRequest request);
    }

    public class IssueRepository : IIssueRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public IssueRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Issue> GetIssues(GetIssueRequest request)
        {
            var result = _dBContext.LoadData<GetIssueRequest, Issue>("sps_Issue", request);

            return result;
        }

        public ResultSingle<Issue> SaveIssue(AddIssueRequest request)
        {
            var result = _dBContext.SaveData<int>("spu_Issue", request);

            return new ResultSingle<Issue>(result.IsSuccess) { Message = result.Message, Data = new Issue { IssueId = result.Data } };
        }
    }
}
