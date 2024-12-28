using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectIconUrl { get; set; }
        public int ProjectCategoryId { get; set; } // SOFTWARE PROJECT | SERVICE MANAGEMENT | WORK MANAGEMENT | MARKETING | HUMAN RESOURCES | FINANCE | DESIGN | PERSONAL | OPERATIONAL | LEGAL | SALES
        public int ProjectTemplateId { get; set; } // KANBAN | SCRUM | BUG TRACKING
        public int ProjectTypeId { get; set; } // TEAM MANAGED | COMPANY MANAGED
        public int ProjectManagerId { get; set; }
        public int ProjectDefaultAssigneeId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public int PrimaryContactId { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string PrimaryContactEmail { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedByUserId { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}