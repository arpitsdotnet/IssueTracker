using System;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface ILogger<T>
    {
        string Log(string message, object object1 = null, object object2 = null);
        string Log(Exception ex, object object1 = null, object object2 = null);
    }
}