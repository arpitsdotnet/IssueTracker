using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Objects;

namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class GetProjectRequest : PageRequest
    {
        private GetProjectRequest() { }

        public int ProjectId { get; set; }
        public int ProjectManagerId { get; set; }
        public int SessionId { get; private set; }

        public static GetProjectRequest Create(
            int ProjectId) => new GetProjectRequest
            {
                ProjectId = ProjectId
            };

        public static GetProjectRequest Generate(
            int SessionId,
            int ProjectId = 0,
            int ProjectManagerId = 0,
            int PageNo = 1,
            short PageSize = 1000) => new GetProjectRequest
            {
                SessionId = SessionId,
                ProjectId = ProjectId,
                ProjectManagerId = ProjectManagerId,
                PageNo = PageNo,
                PageSize = PageSize
            };

        public ResultList<Project> Validate()
        {
            if (SessionId == 0)
                return new ResultList<Project>(false) { Title = "Invalid!", Message = "Login is invalid, please try re-login." };

            return new ResultList<Project>(true);
        }
    }
}
