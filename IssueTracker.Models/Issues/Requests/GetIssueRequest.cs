using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class GetIssueRequest : PageRequest
    {
        private GetIssueRequest() { }

        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public int IssueId { get; set; }
        public short IssueTypeId { get; set; }
        public string IssueKey { get; set; }
        public string IssueTitle { get; set; }

        public static GetIssueRequest Create(
            int UserId,
            int IssueId) => new GetIssueRequest
            {
                UserId = UserId,
                IssueId = IssueId,
            };

        public static GetIssueRequest Create(
            int UserId,
            int ProjectId,
            int IssueId = 0,
            short IssueTypeId = 0,
            string IssueKey = "",
            string IssueTitle = "",
            int PageNo = 1,
            short PageSize = 1000) => new GetIssueRequest
            {
                UserId = UserId,
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
