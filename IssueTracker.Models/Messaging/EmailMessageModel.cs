using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer.Messaging
{
    public class EmailMessageModel
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string CcEmail { get; set; }
        public string CcName { get; set; }
        public string BccEmail { get; set; }
        public string BccName { get; set; }
        public string Subject { get; set; }
        public string PlainContentBody { get; set; }
        public string HtmlContentBody { get; set; }
        public byte[] AttachmentFileByteArray { get; set; }
        public string AttachmentFileName { get; set; }


    }
}
