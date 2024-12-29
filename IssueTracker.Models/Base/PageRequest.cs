using System;

namespace IssueTracker.ModelLayer.Base
{
    public class PageRequest
    {
        public Int32 PageNo { get; set; } = 0;
        public Int16 PageSize { get; set; } = 0;
    }
}
