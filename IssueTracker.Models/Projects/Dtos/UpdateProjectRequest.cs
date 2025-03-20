namespace IssueTracker.ModelLayer.Projects.Dtos
{
    public class UpdateProjectRequest
    {
        public short IssueTypeId { get; set; }
        public int ProjectId { get; set; }
        public string IssueTitle { get; set; }
        public int SessionId { get; private set; }
    }
}
