using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer.Base
{
    public class ResultList<TResponse>
    {
        public ResultList(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; private set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int RecordCount { get; set; }

        public List<TResponse> Data { get; set; }
    }

    public class ResultSingle<TResponse>
    {
        public ResultSingle(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; private set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public TResponse Data { get; set; }
    }
}