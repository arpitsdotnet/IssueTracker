using System;
using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public class MessageService
    {
        // Declare the event
        public event Func<string, string, string, Task<ResultSingle<string>>> MessageSent;

        public async Task<ResultSingle<string>> SendMessage(string sessionUid, string subject, string message)
        {
            // Trigger the event
            return await OnMessageSent(sessionUid, subject, message);
        }

        protected virtual async Task<ResultSingle<string>> OnMessageSent(string sessionUid, string subject, string message)
        {
            return await MessageSent?.Invoke(sessionUid, subject, message);
        }
    }
}
