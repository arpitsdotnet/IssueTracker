﻿namespace IssueTracker.ModelLayer.Projects.Objects
{
    public class ProjectHistory
    {
        public int HistoryId { get; set; }
        public int ProjectId { get; set; }
        public string ModifiedOn { get; set; }
        public int ModifyByUserId { get; set; }
        public string Remarks { get; set; }
    }
}