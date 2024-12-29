namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class CreateProjectRequest
    {
        public string ProjectKey { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectIconUrl { get; set; }
        public short ProjectCategoryId { get; set; }
        public short ProjectTemplateId { get; set; }
        public short ProjectTypeId { get; set; }
        public int CreatedById { get; set; }
    }
}
