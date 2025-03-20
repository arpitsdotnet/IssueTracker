using System;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Requests;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class ProjectCreate : RootPage
    {
        private readonly ProjectController _projectController;

        public ProjectCreate()
        {
            _projectController = new ProjectController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Ddl_ProjectCategory_Bind();
                    Rbl_ProjectTemplate_Bind();
                    Rbl_ProjectType_Bind();
                }
            }
            catch (ArgumentException ex)
            {
                ShowWarning(FileLogger.Log(ex.Message));
            }
            catch (Exception ex)
            {
                ShowError(FileLogger.Log(ex));
            }
        }

        #region Private Members

        private void Ddl_ProjectCategory_Bind()
        {

        }
        private void Rbl_ProjectTemplate_Bind()
        {

        }
        private void Rbl_ProjectType_Bind()
        {

        }

        #endregion


        protected void Txt_ProjectTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_ProjectTitle.Text.Trim()))
                    return;

                string text = Txt_ProjectTitle.Text.Trim();

                Txt_ProjectKey.Text = _projectController.GenerateProjectKey(text);
            }
            catch (ArgumentException ex)
            {
                ShowWarning(FileLogger.Log(ex.Message));
            }
            catch (Exception ex)
            {
                ShowError(FileLogger.Log(ex));
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var projectCategoryId = Convert.ToInt16(Ddl_ProjectCategory.SelectedValue);
                var projectTemplateId = Convert.ToInt16(Rbl_ProjectTemplate.SelectedValue);
                var projectTypeId = Convert.ToInt16(Rbl_ProjectType.SelectedValue);

                var request = AddProjectRequest.Create(
                    SessionUID: Guid.NewGuid().ToString(),
                    ProjTitle: Txt_ProjectTitle.Text.Trim(),
                    ProjKey: Txt_ProjectKey.Text.Trim(),
                    ProjCategoryId: projectCategoryId,
                    ProjTemplateId: projectTemplateId,
                    ProjTypeId: projectTypeId,
                    ProjIconUrl: ""
                );

                var response = _projectController.CreateProject(request);

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
                ShowError(FileLogger.Log(ex));
            }
        }
    }
}