using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<T> DataList { get; set; }

        public void AddItem(T issue)
        {
            if (DataList is null) 
                DataList = new List<T>();
            DataList.Add(issue);
        }
    }
}