using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Validations;

namespace IssueTracker.BusinessLayer.Features.Issues.Dtos
{
    public class GetIssueRequest : PageRequest
    {
        private GetIssueRequest() { }

        public string ClientUID { get; private set; }
        public string SessionUID { get; private set; }
        public int ProjectId { get; set; }
        public int IssueId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueKey { get; set; }
        public string IssueTitle { get; set; }

        public static GetIssueRequest Create(
            string ClientUID,
            string SessionUID,
            int ProjectId,
            int IssueId = 0,
            short IssueTypeId = 0,
            string IssueKey = "",
            string IssueTitle = "",
            int PageNo = 1,
            short PageSize = 100)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);
            ProjectValidationRules.ProjectId.IsRequired(ProjectId);
            IssueValidationRules.IssueKey.HasValidLength(IssueKey);
            IssueValidationRules.IssueTitle.HasValidLength(IssueTitle);
            PageRequestValidationRules.Validate(PageNo, PageSize);

            return new GetIssueRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                ProjectId = ProjectId,
                IssueId = IssueId,
                IssueTypeId = IssueTypeId,
                IssueKey = IssueKey,
                IssueTitle = IssueTitle,
                PageNo = PageNo,
                PageSize = PageSize
            };
        }
    }
}
