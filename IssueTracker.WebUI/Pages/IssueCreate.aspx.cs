using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Requests;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class IssueCreate : RootPage
    {
        private readonly IssueController _issueController;

        public IssueCreate()
        {
            _issueController = new IssueController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var request = AddIssueRequest.Create(Guid.NewGuid().ToString(), 1, 1, "Title");

                var response = _issueController.AddIssue(request);

                if (response.IsSuccess == false)
                    ShowWarning(response.Message, response.Title);

                ShowSuccess(response.Message, response.Title);
            }
            catch (FieldValidationException ex)
            {
                ShowWarning(ex.Message, ex.Title);
            }
            catch (Exception ex)
            {
                ShowError(Logger.Log(ex));
            }
        }
    }
}