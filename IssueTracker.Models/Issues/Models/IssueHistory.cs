namespace IssueTracker.ModelLayer.Issues.Models
{
    public class IssueHistory
    {
        public int IssueId { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifyByUserName { get; set; }
        public string Remarks { get; set; }
    }
}