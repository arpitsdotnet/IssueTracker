using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.Users.Objects;

namespace IssueTracker.ModelLayer.Projects.Objects
{
    public class Project
    {
        public int ProjId { get; set; }
        public string ProjKey { get; set; }
        public string ProjTitle { get; set; }
        public string ProjIconUrl { get; set; }
        public short ProjCategoryId { get; set; }
        public ProjectCategory ProjCategory { get; set; }
        public short ProjTemplateId { get; set; }
        public ProjectTemplate ProjTemplate { get; set; }
        public short ProjTypeId { get; set; }
        public ProjectType ProjType { get; set; }
        public int ProjManagerId { get; set; }
        public User ProjManager { get; set; }
        public int ProjDefaultAssigneeId { get; set; }
        public User ProjDefaultAssignee { get; set; }
        public string ClientName { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string PrimaryContactEmail { get; set; }

        public ProjectRowStatus RowStatus { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedById { get; set; }
        public User LastModifiedBy { get; set; }
    }
}