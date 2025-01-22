using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;
using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class AddIssueRequest
    {
        private AddIssueRequest() { }
        private AddIssueRequest(
            string SessionUId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle)
        {
            this.SessionUId = SessionUId;
            this.ProjectId = ProjectId;
            this.IssueTypeId = IssueTypeId;
            this.IssueTitle = IssueTitle;
        }

        public string SessionUId { get; private set; }
        public int ProjectId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueTitle { get; set; }

        public static AddIssueRequest Create(
            string SessionUId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle)
        {
            SessionValidationRules.SessionUID.IsRequired(SessionUId);

            ProjectValidationRules.ProjectId.IsRequired(ProjectId);

            IssueValidationRules.IssueTypeId.IsRequired(IssueTypeId);

            IssueValidationRules.IssueTitle.IsRequired(IssueTitle);
            IssueValidationRules.IssueTitle.HasValidLength(IssueTitle);

            return new AddIssueRequest(
                SessionUId,
                ProjectId,
                IssueTypeId,
                IssueTitle);
        }
    }
}
