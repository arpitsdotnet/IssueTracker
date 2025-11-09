using System;
using System.Linq;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.SysSubCategories.Dtos;
using IssueTracker.ModelLayer.SysSubCategories.Models;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class ProjectCreate : RootPage
    {
        private readonly SubCategoryController _subCategoryController;
        private readonly ProjectController _projectController;

        public ProjectCreate()
        {
            _subCategoryController = new SubCategoryController();
            _projectController = new ProjectController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleWebException(() =>
            {
                if (!IsPostBack)
                {
                    Ddl_ProjectCategory_Bind();
                    Rbl_ProjectTemplate_Bind();
                    Rbl_ProjectType_Bind();
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
            catch(FieldValidationException ex)
            {
                ShowWarning(ex.Message);
            }
            catch (ArgumentException ex)
            {
                ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                FileLogger.Log(ex);
                ShowError(ex.Message);
            }
        }

        private void Ddl_ProjectCategory_Bind()
        {
            var request = GetSubCategoryRequest.CreateProjectCategoryObject(
                ClientUID: Guid.NewGuid().ToString(),
                SessionUID: Guid.NewGuid().ToString()
            );

            var result = _subCategoryController.GetSubCategories(request);

            if (result.HasValue == false)
            {
                throw new ArgumentException(result.Message);
            }

            Ddl_ProjectCategory.BindData(result.Data, nameof(SubCategory.SubcTitle), nameof(SubCategory.SubcId), "");
        }
        private void Rbl_ProjectTemplate_Bind()
        {
            var request = GetSubCategoryRequest.CreateProjectTemplateObject(
                ClientUID: Guid.NewGuid().ToString(),
                SessionUID: Guid.NewGuid().ToString()
            );

            var result = _subCategoryController.GetSubCategories(request);

            if (result.HasValue == false)
            {
                throw new ArgumentException(result.Message);
            }

            Rbl_ProjectTemplate.BindData(result.Data, nameof(SubCategory.SubcTitle), nameof(SubCategory.SubcId), "");
            if (Rbl_ProjectTemplate.Items.Count > 0)
            {
                Rbl_ProjectTemplate.SelectedIndex = 0;
            }
        }
        private void Rbl_ProjectType_Bind()
        {
            var request = GetSubCategoryRequest.CreateProjectTypeObject(
                ClientUID: Guid.NewGuid().ToString(),
                SessionUID: Guid.NewGuid().ToString()
            );

            var result = _subCategoryController.GetSubCategories(request);

            if (result.HasValue == false)
            {
                throw new ArgumentException(result.Message);
            }

            Rbl_ProjectType.BindData(result.Data, nameof(SubCategory.SubcTitle), nameof(SubCategory.SubcId), "");
            if (Rbl_ProjectType.Items.Count > 0)
            {
                Rbl_ProjectType.SelectedIndex = 0;
            }
        }

        #endregion


        protected void Txt_ProjectTitle_TextChanged(object sender, EventArgs e)
        {
            HandleWebException(() =>
            {
                if (string.IsNullOrEmpty(Txt_ProjectTitle.Text.Trim()))
                    return;

                string text = Txt_ProjectTitle.Text.Trim();

                var result = _projectController.GenerateProjectKey(text);

                if (result.HasValue == false)
                {
                    throw new ArgumentException(result.Message);
                }

                Txt_ProjectKey.Text = result.Data.First();
            });
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            HandleWebException(() =>
            {
                var projectCategoryId = Convert.ToInt16(Ddl_ProjectCategory.SelectedValue);
                var projectTemplateId = Convert.ToInt16(Rbl_ProjectTemplate.SelectedValue);
                var projectTypeId = Convert.ToInt16(Rbl_ProjectType.SelectedValue);

                var request = AddProjectRequest.Create(
                    ClientUID: Guid.NewGuid().ToString(),
                    SessionUID: Guid.NewGuid().ToString(),
                    ProjTitle: Txt_ProjectTitle.Text,
                    ProjKey: Txt_ProjectKey.Text,
                    ProjCategoryId: projectCategoryId,
                    ProjTemplateId: projectTemplateId,
                    ProjTypeId: projectTypeId,
                    ProjIconUrl: ""
                );

                var result = _projectController.CreateProject(request);

                if (result.HasValue == false)
                {
                    throw new ArgumentException(result.Message);
                }

                ShowSuccess(result.Message);
            });
        }
    }
}