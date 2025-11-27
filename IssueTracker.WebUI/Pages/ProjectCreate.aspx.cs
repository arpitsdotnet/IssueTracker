using System;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Features.Projects.CreateProject;
using IssueTracker.BusinessLayer.Features.Projects.CreateProjectKey;
using IssueTracker.BusinessLayer.Features.SysCategories.GetSubCategoriesByCategoryCode;
using IssueTracker.BusinessLayer.Features.SysCategories.Models;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class ProjectCreate : RootPage
    {
        private readonly GetSysSubCategoriesByCategoryCodeController _getSubCategoriesByCategoryCodeHandler;
        private readonly CreateProjectKeyController _createProjectKeyHandler;
        private readonly CreateProjectController _createProjectHandler;

        public ProjectCreate()
        {
            _getSubCategoriesByCategoryCodeHandler = new GetSysSubCategoriesByCategoryCodeController();
            _createProjectKeyHandler = new CreateProjectKeyController();
            _createProjectHandler = new CreateProjectController();
        }

        protected async Task Page_Load(object sender, EventArgs e)
        {
            //await HandleWebException(() =>
            {
                if (!IsPostBack)
                {
                    await Ddl_ProjectCategory_Bind();
                    await Rbl_ProjectTemplate_Bind();
                    await Rbl_ProjectType_Bind();
                }
            }//);
        }

        #region Private Members

        //protected async Task HandleWebException(Action action)
        //{
        //    try
        //    {
        //        await action.Invoke();
        //    }
        //    catch (FieldValidationException ex)
        //    {
        //        ShowWarning(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        ShowWarning(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        FileLogger.Log(ex);
        //        ShowError(ex.Message);
        //    }
        //}

        private async Task Ddl_ProjectCategory_Bind()
        {
            var request = new GetSysSubCategoriesByCategoryCodeRequest
            {
                ClientUID = Guid.NewGuid().ToString(),
                SessionUID = Guid.NewGuid().ToString(),
                CategoryCode = "PROJECT_CATEGORY"
            };

            var result = await _getSubCategoriesByCategoryCodeHandler.Handle(request);

            if (result.HasValue == false)
            {
                throw new ArgumentException(result.Message);
            }

            Ddl_ProjectCategory.BindData(result.Data, nameof(SubCategory.SubcTitle), nameof(SubCategory.SubcId), "");
        }
        private async Task Rbl_ProjectTemplate_Bind()
        {
            var request = new GetSysSubCategoriesByCategoryCodeRequest
            {
                ClientUID = Guid.NewGuid().ToString(),
                SessionUID = Guid.NewGuid().ToString(),
                CategoryCode = "PROJECT_TEMPLATE"
            };

            var result = await _getSubCategoriesByCategoryCodeHandler.Handle(request);

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
        private async Task Rbl_ProjectType_Bind()
        {
            var request = new GetSysSubCategoriesByCategoryCodeRequest
            {
                ClientUID = Guid.NewGuid().ToString(),
                SessionUID = Guid.NewGuid().ToString(),
                CategoryCode = "PROJECT_TYPE"
            };

            var result = await _getSubCategoriesByCategoryCodeHandler.Handle(request);

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
            var request = new CreateProjectKeyRequest { Text = Txt_ProjectTitle.Text.Trim() };

            var result = _createProjectKeyHandler.Handle(request);

            if (result.IsSuccess == false)
            {
                throw new ArgumentException(result.Message);
            }

            Txt_ProjectKey.Text = result.Value.Key;
        }

        protected async Task Btn_Submit_Click(object sender, EventArgs e)
        {
            var projectCategoryId = Convert.ToInt16(Ddl_ProjectCategory.SelectedValue);
            var projectTemplateId = Convert.ToInt16(Rbl_ProjectTemplate.SelectedValue);
            var projectTypeId = Convert.ToInt16(Rbl_ProjectType.SelectedValue);

            var request = new CreateProjectRequest
            {
                ClientUID = Guid.NewGuid().ToString(),
                SessionUID = Guid.NewGuid().ToString(),
                ProjTitle = Txt_ProjectTitle.Text,
                ProjKey = Txt_ProjectKey.Text,
                ProjCategoryId = projectCategoryId,
                ProjTemplateId = projectTemplateId,
                ProjTypeId = projectTypeId,
                ProjIconUrl = ""
            };

            var result = await _createProjectHandler.Handle(request);

            if (result.HasValue == false)
            {
                throw new ArgumentException(result.Message);
            }

            ShowSuccess(result.Message);
        }
    }
}