using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.Issues.Dtos
{
    public class AddIssueRequest
    {
        private AddIssueRequest() { }
        private AddIssueRequest(
            string ClientUId,
            string SessionUId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle)
        {
            this.ClientUId = ClientUId;
            this.SessionUId = SessionUId;
            this.ProjectId = ProjectId;
            this.IssueTypeId = IssueTypeId;
            this.IssueTitle = IssueTitle;
        }

        public string ClientUId { get; private set; }
        public string SessionUId { get; private set; }
        public int ProjectId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueTitle { get; set; }

        public static AddIssueRequest Create(
            string ClientUId,
            string SessionUId,
            int ProjectId,
            short IssueTypeId,
            string IssueTitle)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUId);
            SessionValidationRules.SessionUID.IsRequired(SessionUId);

            ProjectValidationRules.ProjectId.IsRequired(ProjectId);

            IssueValidationRules.IssueTypeId.IsRequired(IssueTypeId);

            IssueValidationRules.IssueTitle.IsRequired(IssueTitle);
            IssueValidationRules.IssueTitle.HasValidLength(IssueTitle);

            return new AddIssueRequest(
                ClientUId,
                SessionUId,
                ProjectId,
                IssueTypeId,
                IssueTitle);
        }
    }
}
