using System;
using System.Web.UI;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.WebUIHelper
{
    public class RootPage : System.Web.UI.Page
    {
        #region Private Methods

        private void ShowMessage(string message, string title, string type = "error")
        {
            message = message.Replace("\"", "`").Replace("\'", "`");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), $"{DateTime.Now:yyMMddHHmmss}", $"toastr[\"{type}\"](\"{message}\", \"{title}\")", true);

        }

        #endregion

        public void ShowError(string message, string title = "Error") => ShowMessage(message, title, "error");
        public void ShowWarning(string message, string title = "Warning") => ShowMessage(message, title, "warning");
        public void ShowWarning(FieldValidationException ex) => ShowMessage(ex.Message, ex.Title, "error");
        public void ShowInfo(string message, string title = "Info") => ShowMessage(message, title, "info");
        public void ShowSuccess(string message, string title = "Success") => ShowMessage(message, title, "success");
    }
}