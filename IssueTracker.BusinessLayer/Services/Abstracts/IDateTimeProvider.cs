using System;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
    }
}
