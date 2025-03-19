using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer.Messaging
{
    public class WhatsappMessageModel
    {
        public string MessagingProduct { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public WhatsappTemplateModel Template { get; set; }

    }

    public class WhatsappTemplateModel
    {
        public string Name { get; set; }
        public WhatsappLanguageModel Language { get; set; }
        public List<WhatsappComponentModel> Components { get; set; }
    }

    public class WhatsappLanguageModel
    {
        public string Code { get; set; }
    }

    public class WhatsappComponentModel
    {
        public string Type { get; set; }
        public List<WhatsappParameterModel> Parameters { get; set; }
    }

    public class WhatsappParameterModel
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }


}
