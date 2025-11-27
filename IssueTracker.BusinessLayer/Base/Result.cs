using System.Collections.Generic;

namespace IssueTracker.BusinessLayer.Base
{
    public sealed class Result<T> where T : class
    {
        private Result(T value, string message)
        {
            Value = value;
            Message = message;
            IsSuccess = true;
        }
        private Result(Error error)
        {
            Error = error;
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public T Value { get; }
        public string Message { get; }

        public static Result<T> Success(T value, string message = null) => new Result<T>(value, message);
        public static Result<T> Failure(Error error) => new Result<T>(error);
    }

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