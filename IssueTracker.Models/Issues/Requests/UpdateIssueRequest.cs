﻿namespace IssueTracker.ModelLayer.Issues.Requests
{
    public class UpdateIssueRequest
    {
        public short IssueTypeId { get; set; }
        public int ProjectId { get; set; }
        public string IssueTitle { get; set; }
        public int CreatedById { get; set; }
    }
}
