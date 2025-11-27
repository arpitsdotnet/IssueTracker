using System;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Abstracts;

namespace IssueTracker.BusinessLayer.Extensions.ExceptionHandlers
{
    public static class DefaultExceptionHandler
    {
        public static async Task<ResultList<UResponse>> Handle<TController, UResponse>(ILogger<TController> logger, Func<Task<ResultList<UResponse>>> action)
        {
            try
            {
                return await action.Invoke();
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
