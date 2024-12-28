using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer
{
    /// <summary>
    /// TO-DO | IN-PROGRESS | DONE
    /// </summary>
    public class IssueStatus
    {
        public Int16 IssueStatusId { get; set; }
        public string IssueStatusTitle { get; set; }
    }
}
