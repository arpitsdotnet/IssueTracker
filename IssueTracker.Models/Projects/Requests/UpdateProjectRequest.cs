using System;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class UpdateProjectRequest
    {
        public short IssueTypeId { get; set; }
        public int ProjectId { get; set; }
        public string IssueTitle { get; set; }
        public int CreatedById { get; set; }
    }
}
