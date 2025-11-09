using System;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Dtos;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;
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
            HandleWebException(() =>
            {
                if (!IsPostBack)
                {
                    Project_DropdownBind();
                }
            });
        }

        #region Private Members

        protected void HandleWebException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void Project_DropdownBind()
        {
            string ClientUID = Guid.NewGuid().ToString();
            string SessionUID = Guid.NewGuid().ToString();

            GetProjectRequest request = GetProjectRequest.Create(ClientUID, SessionUID);

            var projectResult = _projectController.GetProjects(request);
            if (projectResult.HasValue == false)
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
            HandleWebException(() =>
            {
                var request = AddIssueRequest.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1, 1, "Title");

                var response = _issueController.CreateIssue(request);

                if (response.HasValue == false)
                    ShowWarning(response.Message, response.Title);

                ShowSuccess(response.Message, response.Title);
            });
        }
    }
}