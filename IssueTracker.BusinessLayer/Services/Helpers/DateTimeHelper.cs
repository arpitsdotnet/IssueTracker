using System;
using IssueTracker.BusinessLayer.Services.Abstracts;

namespace IssueTracker.BusinessLayer.Services.Helpers
{
    public class DateTimeHelper : IDateTimeProvider
    {
        public DateTime DateTimeNow => DateTime.Now;
    }
}
