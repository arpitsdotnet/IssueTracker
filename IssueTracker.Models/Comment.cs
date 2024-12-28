using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentTitle { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public int EpicId { get; set; }
        public string EpicTitle { get; set; }
        public int IssueId { get; set; }
        public string IssueTitle { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedByUserId { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}