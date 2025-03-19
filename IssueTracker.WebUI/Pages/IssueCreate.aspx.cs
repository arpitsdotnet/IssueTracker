using System;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Requests;
using IssueTracker.ModelLayer.Projects.Objects;
using IssueTracker.ModelLayer.Projects.Requests;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class IssueCreate : RootPage
    {
        private readonly ProjectController _projectController;
        private readonly IssueController _issueController;

        public IssueCreate()
        {
            _projectController = new ProjectController();
            _issueController = new IssueController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Project_DropdownBind();
                }
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

        #region Private Members

        private void Project_DropdownBind()
        {
            string ClientUID = Guid.NewGuid().ToString();
            string SessionUID = Guid.NewGuid().ToString();

            GetProjectRequest request = GetProjectRequest.Create(ClientUID, SessionUID);

            var projectResult = _projectController.GetProjects(request);
            if (projectResult.IsSuccess == false)
            {
                ShowWarning(projectResult.Message, nameof(Project));
                return;
            }

            var project = new Project();

            Ddl_Projects.BindData(projectResult.Data, nameof(project.ProjTitle), nameof(project.ProjId));
        }

        #endregion

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var request = AddIssueRequest.Create(Guid.NewGuid().ToString(), 1, 1, "Title");

                var response = _issueController.CreateIssue(request);

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