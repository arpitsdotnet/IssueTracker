using System;
using System.Linq;
using IssueTracker.BusinessLayer.Controllers;
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
            }
            catch (ArgumentException ex)
            {
                ShowWarning(Logger.Log(ex.Message));
            }
            catch (Exception ex)
            {
                ShowError(Logger.Log(ex));
            }
        }


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
                ShowWarning(Logger.Log(ex.Message));
            }
            catch (Exception ex)
            {
                ShowError(Logger.Log(ex));
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var projectCategoryId = Convert.ToInt16(Ddl_ProjectCategory.SelectedValue);
                var projectTemplateId = Convert.ToInt16(Ddl_ProjectTemplate.SelectedValue);
                var projectTypeId = Convert.ToInt16(Rbl_ProjectType.SelectedValue);

                var project = CreateProjectRequest.Generate(   
                    SessionId: 1,
                    ProjTitle: Txt_ProjectTitle.Text.Trim(),
                    ProjKey: Txt_ProjectKey.Text.Trim(),
                    ProjCategoryId: projectCategoryId,
                    ProjTemplateId: projectTemplateId,
                    ProjTypeId: projectTypeId,
                    ProjIconUrl: ""
                );

                var result = _projectController.SaveProject(project);

                if (result.IsSuccess == false)
                    ShowWarning(result.Message);

                ShowSuccess(result.Message);
            }
            catch (ArgumentException ex)
            {
                ShowWarning(Logger.Log(ex.Message));
            }
            catch (Exception ex)
            {
                ShowError(Logger.Log(ex));
            }
        }
    }
}