using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Objects;
using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class GetProjectRequest : PageRequest
    {
        private GetProjectRequest() { }

        public string SessionUID { get; private set; }
        public int ProjectId { get; set; }
        public int ProjectManagerId { get; set; }

        public static GetProjectRequest Create(
            int ProjectId) => new GetProjectRequest
            {
                ProjectId = ProjectId
            };

        public static GetProjectRequest Generate(
            string SessionUID,
            int ProjectId = 0,
            int ProjectManagerId = 0,
            int PageNo = 1,
            short PageSize = 1000)
        {
            SessionValidationRules.SessionUID.IsRequired(SessionUID);
            PageRequestValidationRules.Validate(PageNo, PageSize);

            return new GetProjectRequest
            {
                SessionUID = SessionUID,
                ProjectId = ProjectId,
                ProjectManagerId = ProjectManagerId,
                PageNo = PageNo,
                PageSize = PageSize
            };
        }
    }
}
