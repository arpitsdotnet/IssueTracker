using System.Collections.Generic;
using IssueTracker.ModelLayer.Projects.Objects;
using IssueTracker.ModelLayer.Sprints.Objects;
using IssueTracker.ModelLayer.Users.Objects;

namespace IssueTracker.ModelLayer.Issues.Objects
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string IssueKey { get; set; }
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public short IssueTypeId { get; set; } // EPIC | STORY | TASK | SUB-TASK | BUG
        public IssueType IssueType { get; set; }
        public short IssuePriorityId { get; set; } // HIGH | MEDIUM | LOW
        public IssuePriority IssuePriority { get; set; }
        public int ParentIssueId { get; set; }
        public Issue ParentIssue { get; set; }
        public short IssueStatusId { get; set; } // TO-DO | IN-PROGRESS | DONE
        public IssueStatus IssueStatus { get; set; }
        public string IssueEndDate { get; set; }

        public string EpicStartDate { get; set; }
        public string EpicDueDate { get; set; }

        public short StoryPointEstimate { get; set; }
        public int StorySprintId { get; set; }
        public Sprint StorySprint { get; set; }
        public int StoryManagerId { get; set; }
        public User StoryManager { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedById { get; set; }
        public User LastModifiedBy { get; set; }


        public List<string> IssueLabelList { get; set; }
        public void AddIssueLabelItem(string item)
        {
            if (IssueLabelList is null) IssueLabelList = new List<string>();
            IssueLabelList.Add(item);
        }

        public List<Issue> ParentIssueList { get; set; }
        public void AddParentIssueItem(Issue item)
        {
            if (ParentIssueList is null) ParentIssueList = new List<Issue>();
            ParentIssueList.Add(item);
        }

        public List<IssueHistory> HistoryList { get; set; }
        public void AddIssueHistoryItem(IssueHistory item)
        {
            if (HistoryList is null) HistoryList = new List<IssueHistory>();
            HistoryList.Add(item);
        }

        public List<Log> Logs { get; set; }
        public void AddLogItem(Log item)
        {
            if (Logs is null) Logs = new List<Log>();
            Logs.Add(item);
        }

    }
}