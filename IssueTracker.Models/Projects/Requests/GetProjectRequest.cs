using System;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class GetProjectRequest : PageRequest
    {
        private GetProjectRequest() { }

        public int UserId { get; set; }

        public int ProjectId { get; set; }
        public int ProjectManagerId { get; set; }

        public static GetProjectRequest Create(
            int UserId,
            int ProjectId) => new GetProjectRequest
            {
                UserId = UserId,
                ProjectId = ProjectId
            };

        public static GetProjectRequest Create(
            int UserId,
            int ProjectId = 0,
            int ProjectManagerId = 0,
            int PageNo = 1,
            short PageSize = 1000) => new GetProjectRequest
            {
                UserId = UserId,
                ProjectId = ProjectId,
                ProjectManagerId = ProjectManagerId,
                PageNo = PageNo,
                PageSize = PageSize
            };
    }
}
