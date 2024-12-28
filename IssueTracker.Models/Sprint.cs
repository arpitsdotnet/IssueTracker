using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public string SprintTitle { get; set; }
        public int SprintDurationId { get; set; } // 1 WEEK | 2 WEEKS | 3 WEEKS | 4 WEEKS
        public string SprintStartDate { get; set; }
        public string SprintEndDate { get; set; }
        public string SprintGoal { get; set; }

    }
}