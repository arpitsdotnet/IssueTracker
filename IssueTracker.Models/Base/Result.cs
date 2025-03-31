using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer.Base
{
    public class ResultList<TResponse>
    {
        public ResultList(bool hasValue)
        {
            HasValue = hasValue;
        }

        public bool HasValue { get; private set; }
        public short StatusCode { get; set; } = 200;
        public string Title { get; set; } = "Success!";
        public string Message { get; set; }
        public long RecordCount { get; set; }

        public List<TResponse> Data { get; set; }

        //public List<TResponse> AddResultItem(TResponse response)
        //{
        //    if (Data == null)
        //        Data = new List<TResponse>();
        //    Data.Add(response);
        //    return 
        //}
    }

    public class ResultSingle<TResponse>
    {
        public ResultSingle(bool hasValue)
        {
            HasValue = hasValue;
        }

        public bool HasValue { get; private set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public TResponse Data { get; set; }
    }
}