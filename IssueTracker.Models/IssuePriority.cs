using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer
{
    /// <summary>
    /// HIGH | MEDIUM | LOW
    /// </summary>
    public class IssuePriority
    {
        public Int16 IssuePriorityId { get; set; } 
        public string IssuePriorityTitle { get; set; }
    }
}
