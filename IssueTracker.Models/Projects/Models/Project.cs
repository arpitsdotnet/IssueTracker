using IssueTracker.ModelLayer.Clients.Objects;
using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.SysSubCategories.Models;
using IssueTracker.ModelLayer.Users.Models;

namespace IssueTracker.ModelLayer.Projects.Models
{
    public class Project
    {
        public int ProjId { get; set; }

        public string ClientUID { get; set; }
        public virtual Client Client { get; set; }

        public string CreatedOn { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public virtual string LastModifiedOn { get; set; }

        public int LastModifiedById { get; set; }
        public virtual User LastModifiedBy { get; set; }

        public ProjectStatuses ProjStatus { get; set; }

        public string ProjKey { get; set; }
        public string ProjTitle { get; set; }
        public string ProjIconUrl { get; set; }

        public short ProjCategoryId { get; set; }
        public virtual SubCategory ProjCategory { get; set; }

        public short ProjTemplateId { get; set; }
        public virtual SubCategory ProjTemplate { get; set; }

        public short ProjTypeId { get; set; }
        public virtual SubCategory ProjType { get; set; }

        public int ProjManagerId { get; set; }
        public virtual User ProjManager { get; set; }

        public int ProjDefaultAssigneeId { get; set; }
        public virtual User ProjDefaultAssignee { get; set; }

    }
}