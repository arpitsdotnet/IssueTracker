using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer.Base
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
