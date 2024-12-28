using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace IssueTracker.WebUIHelper
{
    public class RootPage : System.Web.UI.Page
    {
        public void ShowError(string message) => ShowMessage(message, "error");
        public void ShowWarning(string message) => ShowMessage(message, "warning");
        public void ShowInfo(string message) => ShowMessage(message, "info");
        public void ShowSuccess(string message) => ShowMessage(message, "success");
        private void ShowMessage(string message, string type = "error")
        {
            message = message.Replace("\"", "`").Replace("\'", "`");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), $"{DateTime.Now:yyMMddHHmmss}", $"toastr[\"{type}\"](\"{message}\", \"Success\")", true);

        }
    }
}