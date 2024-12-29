using IssueTracker.ModelLayer.Users.Objects;

namespace IssueTracker.ModelLayer.Projects.Objects
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectIconUrl { get; set; }
        public short ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public short ProjectTemplateId { get; set; }
        public ProjectTemplate ProjectTemplate { get; set; }
        public short ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        public int ProjectManagerId { get; set; }
        public User ProjectManager { get; set; }
        public int ProjectDefaultAssigneeId { get; set; }
        public User ProjectDefaultAssignee { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public int PrimaryContactId { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string PrimaryContactEmail { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedById { get; set; }
        public User LastModifiedBy { get; set; }
    }
}