namespace IssueTracker.ModelLayer.Issues.Objects
{
    /// <summary>
    /// HIGH | MEDIUM | LOW
    /// </summary>
    public class IssuePriority
    {
        public short IssuePriorityId { get; set; }
        public string IssuePriorityTitle { get; set; }
    }
}
