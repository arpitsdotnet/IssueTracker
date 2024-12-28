using System;

namespace IssueTracker.ModelLayer
{
    /// <summary>
    /// EPIC | STORY | TASK | SUB-TASK | BUG
    /// </summary>
    /// <example>
    /// EPIC : ROADMAP | LONG TERM PLAN | 6 MONTHS (KEY: <PROJECTKEY>.<IssueId>)
    /// STORY : BACKLOG | SHORT TERM PLAN | 1 MONTH OR 1 SPRINT (KEY: <PROJECTKEY>.<IssueId>)
    /// TASK : TASK | 1 DAY to 1 WEEK (KEY: <PROJECTKEY>.<IssueId>)
    /// SUB-TASK : SMALL TASK | 1 DAY to 1 WEEK (KEY: <PROJECTKEY>.<IssueId>)
    /// BUG : BUG ISSUE (KEY: <PROJECTKEY>.<YYMDD>.<DaySrNo>)
    /// </example>
    public class IssueType
    {
        public Int16 IssueTypeId { get; set; }
        public string IssueTypeTitle { get; set; }

    }
}
