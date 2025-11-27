using System;

namespace IssueTracker.BusinessLayer.Base
{
    public class FieldValidationException : Exception
    {
        public string Title { get; set; }

        public FieldValidationException(string title, string message) : base(message)
        {
            Title = title;
        }

        public FieldValidationException(string title, string message, Exception innerException) : base(message, innerException)
        {
            Title = title;
        }
    }
}
