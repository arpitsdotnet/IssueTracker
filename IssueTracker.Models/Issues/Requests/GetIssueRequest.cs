using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;

namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class GetIssueRequest : PageRequest
    {
        private GetIssueRequest() { }

        public int ProjectId { get; set; }

        public int IssueId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueKey { get; set; }
        public string IssueTitle { get; set; }
        public int SessionId { get; private set; }

        public static GetIssueRequest Create(int IssueId) =>
            new GetIssueRequest
            {
                IssueId = IssueId,
            };

        public static GetIssueRequest Create(
            int ProjectId,
            int IssueId = 0,
            short IssueTypeId = 0,
            string IssueKey = "",
            string IssueTitle = "",
            int PageNo = 1,
            short PageSize = 1000) =>
            new GetIssueRequest
            {
                ProjectId = ProjectId,
                IssueId = IssueId,
                IssueTypeId = IssueTypeId,
                IssueKey = IssueKey,
                IssueTitle = IssueTitle,
                PageNo = PageNo,
                PageSize = PageSize
            };

        public ResultList<Issue> Validate()
        {
            if (SessionId == 0)
                return new ResultList<Issue>(false) { Title = "Invalid!", Message = "Login is invalid, please try re-login." };

            if (ProjectId == 0)
                return new ResultList<Issue>(false) { Title = "Required!", Message = $"Please select a {nameof(ProjectId)}." };

            if (string.IsNullOrEmpty(IssueTitle) == false)
            {
                if (IssueTitle.Length < 3)
                    return new ResultList<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueTitle)} must be atleast 3 characters long." };
                if (IssueTitle.Length > 50)
                    return new ResultList<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueTitle)} must not be greater than 50 characters." };
            }

            if (string.IsNullOrEmpty(IssueKey) == false)
            {
                if (IssueKey.Length < 2)
                    return new ResultList<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueKey)} must be atleast 2 characters long." };
                if (IssueKey.Length > 10)
                    return new ResultList<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueKey)} must not be greater than 10 characters." };
            }

            return new ResultList<Issue>(true);
        }
    }
}
