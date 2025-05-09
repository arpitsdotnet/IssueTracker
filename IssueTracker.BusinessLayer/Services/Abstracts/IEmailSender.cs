﻿using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface IEmailSender
    {
        Task<ResultSingle<string>> SendAsync(EmailMessageModel model);
    }
}
