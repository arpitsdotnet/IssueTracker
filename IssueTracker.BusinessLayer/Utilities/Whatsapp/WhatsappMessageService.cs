using System;
using System.Collections.Generic;
using IssueTracker.ModelLayer.Messaging;

namespace IssueTracker.BusinessLayer.Utilities.Whatsapp
{
    public class WhatsappMessageService
    {
        #region Private Methods

        private static void GenerateWhatsAppBody(string bodyParams, List<WhatsappComponentModel> componentslist)
        {
            if (string.IsNullOrEmpty(bodyParams))
            {
                return;
            }
            if (bodyParams.Contains("|") == false)
            {
                return;
            }

            List<WhatsappParameterModel> parameterslist = new List<WhatsappParameterModel> { };
            foreach (string x in bodyParams.Split('|'))
            {
                if (x != "" && x != " ")
                {
                    parameterslist.Add(new WhatsappParameterModel { Type = "text", Text = x });
                }
            }
            if (parameterslist.Count == 0)
            {
                return;
            }

            componentslist.AddRange(new List<WhatsappComponentModel> { new WhatsappComponentModel { Type = "body", Parameters = parameterslist } });
        }

        private static void GenerateWhatsappHeader(string headerPeram, List<WhatsappComponentModel> componentslist)
        {
            if (headerPeram == "")
            {
                return;
            }

            List<WhatsappParameterModel> parametersData = new List<WhatsappParameterModel> { new WhatsappParameterModel { Type = "text", Text = headerPeram } };
            componentslist.AddRange(new List<WhatsappComponentModel> { new WhatsappComponentModel { Type = "header", Parameters = parametersData } });
        }

        #endregion


        public static WhatsappMessageModel CreateMessageTemplate(string templateName, string templateLanguage, string headerParams, string bodyParams, string toMobileNo)
        {
            WhatsappMessageModel model = new WhatsappMessageModel();
            try
            {
                List<WhatsappComponentModel> componentslist = new List<WhatsappComponentModel> { };

                GenerateWhatsappHeader(headerParams, componentslist);
                GenerateWhatsAppBody(bodyParams, componentslist);

                model = new WhatsappMessageModel
                {
                    MessagingProduct = "whatsapp",
                    To = toMobileNo,
                    Type = "template",

                    Template = new WhatsappTemplateModel
                    {
                        Name = templateName,
                        Language = new WhatsappLanguageModel { Code = templateLanguage },
                        Components = componentslist
                    }
                };

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
