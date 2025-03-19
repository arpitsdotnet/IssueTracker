using System;
using System.Net;
using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public interface ISMSSender
    {
        Task<ResultSingle<string>> SendAsync(string mobileNumber, string messageBody, string templateId);
    }

    public class DefaultSMSMessageService : ISMSSender
    {
        private readonly DefaultSMSSettingKeyModel _setting;

        public DefaultSMSMessageService(DefaultSMSSettingKeyModel settingKeyModel)
        {
            _setting = settingKeyModel;
        }

        public async Task<ResultSingle<string>> SendAsync(string mobileNumber, string messageBody, string templateId)
        {
            try
            {
                if (mobileNumber.Length < 10)
                    return new ResultSingle<string>(false) { Message = "Mobile Number is not valid.", Data = mobileNumber };
                if (_setting == null)
                    return new ResultSingle<string>(false) { Message = "Setting to send SMS has not been found." };

                string createdURL = "";

                if (_setting.SMSWorkingKey == "")
                    createdURL = $"{ _setting.SMSUrl }sender={ _setting.SMSSenderId }&to={ mobileNumber }&message={ messageBody }";
                else if (_setting.WorkingKeyString != "")
                {
                    // ' ISSUE : If SMS TemplateID String is blank then there should not be any added string.
                    string templateSetting = string.IsNullOrEmpty(_setting.SMSTemplateIdString) ? "" : $"&{ _setting.SMSTemplateIdString }={ templateId }";

                    createdURL = $"{ _setting.SMSUrl }{ _setting.WorkingKeyString }={ _setting.SMSWorkingKey }&{ _setting.SenderIdString }={ _setting.SMSSenderId }{ templateSetting }&{ _setting.MobileNoString }={ mobileNumber }&{ _setting.MessageString }={ messageBody }";
                }
                else
                    createdURL = $"{ _setting.SMSUrl }workingkey={ _setting.SMSWorkingKey }&sender={ _setting.SMSSenderId }&to={ mobileNumber }&message={ messageBody }";

                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(createdURL);
                HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(httpResponse.GetResponseStream());
                string responseString = await respStreamReader.ReadToEndAsync();
                respStreamReader.Close();
                httpResponse.Close();

                return new ResultSingle<string>(true) { Message = "Message has been sent successfully. " + responseString };
            }
            catch (Exception ex)
            {
                //Log4Acc.LogError(ex, MethodBase.GetCurrentMethod());
                return new ResultSingle<string>(false) { Message = "Message has not been sent.", Data = ex.Message };
            }
        }
    }
}
