using System;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Features.Issues.CreateIssue;
using IssueTracker.BusinessLayer.Features.Issues.Dtos;
using IssueTracker.BusinessLayer.Features.Projects.GetProjects;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class IssueCreate : RootPage
    {
        private readonly GetProjectsController _getProjectsController;
        private readonly CreateIssueController _createIssueController;

        public IssueCreate()
        {
            _getProjectsController = new GetProjectsController();
            _createIssueController = new CreateIssueController();
        }

        protected async Task Page_Load(object sender, EventArgs e)
        {
            //HandleWebException(() =>
            {
                if (!IsPostBack)
                {
                    await Project_DropdownBind();
                }
            }//);
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

        private async Task Project_DropdownBind()
        {
            string ClientUID = Guid.NewGuid().ToString();
            string SessionUID = Guid.NewGuid().ToString();

            var request = new GetProjectsRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID
            };

            var projectResult = await _getProjectsController.Handle(request);
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

        protected async Task Btn_Submit_Click(object sender, EventArgs e)
        {
            HandleWebException(async () =>
            {
                string ClientUID = Guid.NewGuid().ToString();
                string SessionUID = Guid.NewGuid().ToString();

                var request = new CreateIssueRequest
                {
                    ClientUID = ClientUID,
                    SessionUID = SessionUID,
                    ProjectId = 1,
                    IssueTypeId = 1,
                    IssueTitle = "Title"
                };

                var response = await _createIssueController.Handle(request);

                if (response.HasValue == false)
                    ShowWarning(response.Message, response.Title);

                ShowSuccess(response.Message, response.Title);
            });
        }
    }
}