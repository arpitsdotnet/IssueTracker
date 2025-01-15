using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;

namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class CreateIssueRequest
    {
        private CreateIssueRequest() { }
        private CreateIssueRequest(
            int SessionId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle)
        {
            this.SessionId = SessionId;
            this.ProjectId = ProjectId;
            this.IssueTypeId = IssueTypeId;
            this.IssueTitle = IssueTitle;
        }

        public int SessionId { get; private set; }
        public int ProjectId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueTitle { get; set; }

        public ResultSingle<Issue> Validate()
        {
            if (SessionId == 0)
                return new ResultSingle<Issue>(false) { Title = "Invalid!", Message = "Login is invalid, please try re-login." };

            if (ProjectId == 0)
                return new ResultSingle<Issue>(false) { Title = "Required!", Message = $"Please select a {nameof(ProjectId)}." };

            if (IssueTypeId == 0)
                return new ResultSingle<Issue>(false) { Title = "Required!", Message = $"Please select a {nameof(IssueTypeId)}." };

            if (string.IsNullOrEmpty(IssueTitle))
                return new ResultSingle<Issue>(false) { Title = "Required!", Message = $"Please enter {nameof(IssueTitle)}." };
            if (IssueTitle.Length < 3)
                return new ResultSingle<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueTitle)} must be atleast 3 characters long." };
            if (IssueTitle.Length > 50)
                return new ResultSingle<Issue>(false) { Title = "Invalid!", Message = $"{nameof(IssueTitle)} must not be greater than 50 characters." };

            return new ResultSingle<Issue>(true);
        }

        public static CreateIssueRequest Generate(
            int SessionId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle) =>
            new CreateIssueRequest(
                SessionId,
                ProjectId,
                IssueTypeId,
                IssueTitle);
    }
}
