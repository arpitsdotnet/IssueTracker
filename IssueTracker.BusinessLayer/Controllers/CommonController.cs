using System;
using System.Configuration;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.DataLayer;
using IssueTracker.ModelLayer.Base;

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

        /* HTTP Status Code 200 (HTTP Response OK)
         * HTTP Status Code 201 (HTTP Response Created)
         * HTTP Status Code 204 (HTTP Response No Content)
         * HTTP Status Code 400 (HTTP Response Bad Request)
         * HTTP Status Code 401 (HTTP Response Unauthorized)
         * HTTP Status Code 403 (HTTP Response Forbidden)
         * HTTP Status Code 404 (HTTP Response NotFound)
         * HTTP Status Code 500 (HTTP Response InternalServerError)
         */

        protected ResultList<UResponse> HandleBusinessException<TController, UResponse>(ILogger<TController> logger, Func<ResultList<UResponse>> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (FieldValidationException ex)
            {
                return new ResultList<UResponse>(false) { StatusCode = 400, Message = ex.Message };
            }
            catch (ArgumentException ex)
            {
                return new ResultList<UResponse>(false) { StatusCode = 400, Message = ex.Message };
            }
            catch (Exception ex)
            {
                return new ResultList<UResponse>(false) { StatusCode = 500, Message = logger.Log(ex) };
            }
        }
    }
}
