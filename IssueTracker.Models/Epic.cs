using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Epic
    {

        public int EpicId { get; set; }
        public string EpicTitle { get; set; }
        public string EpicDescription { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string EpicKey { get; set; }
        public string EpicStartDate { get; set; }
        public string EpicDueDate { get; set; }
        public string EpicEndDate { get; set; }
        public int EpicStatusId { get; set; } // TO-DO | IN-PROGRESS | DONE

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedByUserId { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}