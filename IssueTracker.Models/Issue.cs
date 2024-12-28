using System;
using System.Collections.Generic;

namespace IssueTracker.ModelLayer
{
    public class Issue
    {
        // EPIC : ROADMAP | LONG TERM PLAN | 6 MONTHS (KEY: <PROJECTKEY>.<IssueId>)
        // STORY : BACKLOG | SHORT TERM PLAN | 1 MONTH OR 1 SPRINT (KEY: <PROJECTKEY>.<IssueId>)
        // TASK : TASK | 1 DAY to 1 WEEK (KEY: <PROJECTKEY>.<IssueId>)
        // SUB-TASK : SMALL TASK | 1 DAY to 1 WEEK (KEY: <PROJECTKEY>.<IssueId>)
        // BUG : BUG ISSUE (KEY: <PROJECTKEY>.<YYMDD>.<DaySrNo>)
        public int IssueId { get; set; }
        public string IssueKey { get; set; }
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        public int ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectTitle { get; set; }
        public Int16 IssueTypeId { get; set; } // EPIC | STORY | TASK | SUB-TASK | BUG
        public string IssueTypeTitle { get; set; }
        public Int16 IssuePriorityId { get; set; } // HIGH | MEDIUM | LOW
        public string IssuePriorityTitle { get; set; }
        public Int16 IssueStatusId { get; set; } // TO-DO | IN-PROGRESS | DONE
        public string IssueStatusTitle { get; set; }

        public string EpicStartDate { get; set; }
        public string EpicDueDate { get; set; }

        public Int16 StoryPointEstimate { get; set; } // STORY | TASK | SUB-TASK | BUG
        public Int16 StorySprintId { get; set; } // STORY
        public string StorySprintTitle { get; set; }
        public int StoryReporterUserId { get; set; }
        public string StoryReporterUserName { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedByUserId { get; set; }
        public string LastModifiedByUserName { get; set; }

        public char NewStatus { get; set; }
        public string Remarks { get; set; }
        public bool BtnSubmitYN { get; set; }
        public bool BtnVerifyYN { get; set; }

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

        public List<Log> Logs { get; set; }
        public void AddLogItem(Log item)
        {
            if (Logs is null) Logs = new List<Log>();
            Logs.Add(item);
        }

        public static Issue CreateInitialRequest(
            Int16 IssueTypeId,
            int ProjectId,
            string IssueTitle,
            int CreatedByUserId
            )
        {
            return new Issue
            {
                IssueTypeId = IssueTypeId,
                ProjectId = ProjectId,
                IssueTitle = IssueTitle,
                CreatedByUserId = CreatedByUserId,
            };
        }

        //public Issue CreateRequest(
        //    int IssueId,
        //    string IssueTitle,
        //    string IssueDescription,
        //    Int16 IssuePriorityId,
        //    int ProjectId,
        //    int AddedByUserId,
        //    int VerifyByUserId) => new Issue
        //    {
        //        IssueId = IssueId,
        //        IssueTitle = IssueTitle,
        //        IssueDescription = IssueDescription,
        //        IssuePriorityId = IssuePriorityId,
        //        ProjectId = ProjectId,
        //        AddedByUserId = AddedByUserId,
        //        VerifyByUserId = VerifyByUserId
        //    };

        //public Issue StatusChangeRequest(
        //    int IssueId,
        //    int VerifyByUserId,
        //    char NewStatus,
        //    string Remarks) => new Issue
        //    {
        //        IssueId = IssueId,
        //        VerifyByUserId = VerifyByUserId,
        //        NewStatus = NewStatus,
        //        Remarks = Remarks
        //    };
    }
}