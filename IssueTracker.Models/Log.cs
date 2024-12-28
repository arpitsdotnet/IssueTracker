using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Log
    {
        public string SysDate { get; set; }
        public int AddedByUserId { get; set; }
        public string AddedByUserName { get; set; }
        public string Remarks { get; set; }
    }
}