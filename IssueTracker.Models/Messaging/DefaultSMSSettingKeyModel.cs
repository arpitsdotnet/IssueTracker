using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer.Messaging
{
    public class DefaultSMSSettingKeyModel
    {
        public string SMSWorkingKey { get; set; }
        public string SMSUrl { get; set; }
        public string SMSSenderId { get; set; }
        public string WorkingKeyString { get; set; }
        public string SMSTemplateIdString { get; set; }
        public string SenderIdString { get; set; }
        public string MobileNoString { get; set; }
        public string MessageString { get; set; }
    }
}
