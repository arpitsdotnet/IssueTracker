namespace IssueTracker.ModelLayer.Issues.Objects
{
    public class IssueHistory
    {
        public int HistoryId { get; set; }
        public int IssueId { get; set; }
        public string ModifiedOn { get; set; }
        public int ModifyByUserId { get; set; }
        public string Remarks { get; set; }
    }
}