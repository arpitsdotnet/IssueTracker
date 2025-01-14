namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class UpdateIssueRequest
    {
        private UpdateIssueRequest() { }

        public short IssueTypeId { get; set; }
        public int ProjectId { get; set; }
        public string IssueTitle { get; set; }
        public int SessionId { get; private set; }
    }
}
