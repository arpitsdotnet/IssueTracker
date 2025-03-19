using System;
using System.Configuration;
using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.DataLayer;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class CommonController
    {
        public readonly IApplicationDBContext _dBContext;
        public readonly IEmailSender _emailService;
        public CommonController()
        {
            _dBContext = SQLDataAccess.Instance;
            //_emailService = new DefaultEmailMessageService();
        }

        public string GetAppSettingKey(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].Trim();
            }
            catch
            {
                throw new Exception("Unable to find App Setting Key : " + key);
            }
        }
    }
}
