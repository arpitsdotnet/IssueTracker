namespace IssueTracker.BusinessLayer.Features.Comments.Models
{
    public class CommentHistory
    {
        public int HistoryId { get; set; }
        public int CommentId { get; set; }
        public string ModifiedOn { get; set; }
        public int ModifyByUserId { get; set; }
        public string Remarks { get; set; }
    }
}