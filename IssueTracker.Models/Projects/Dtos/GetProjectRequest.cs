using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.Projects.Dtos
{
    public class GetProjectRequest : PageRequest
    {
        private GetProjectRequest() { }

        public string ClientUID { get; private set; }
        public string SessionUID { get; private set; }
        public int ProjectId { get; set; }
        public int ProjectManagerId { get; set; }

        public static GetProjectRequest Create(
            string ClientUID,
            string SessionUID,
            int ProjectId = 0)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);

            return new GetProjectRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                ProjectId = ProjectId
            };
        }

        public static GetProjectRequest Generate(
            string ClientUID,
            string SessionUID,
            int ProjectId = 0,
            int ProjectManagerId = 0,
            int PageNo = 1,
            short PageSize = 1000)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);
            PageRequestValidationRules.Validate(PageNo, PageSize);

            return new GetProjectRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                ProjectId = ProjectId,
                ProjectManagerId = ProjectManagerId,
                PageNo = PageNo,
                PageSize = PageSize
            };
        }
    }
}
