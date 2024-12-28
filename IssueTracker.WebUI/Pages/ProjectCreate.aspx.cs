using System;
using System.Linq;
using IssueTracker.WebUIHelper;

namespace IssueTracker.WebUI.Pages
{
    public partial class ProjectCreate : RootPage
    {
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

        #region Private Members

        private string GenerateProjectKey(string text)
        {
            char[] characterToRemove = { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            string filteredText = "";
            foreach (char character in text.ToCharArray())
            {
                if (characterToRemove.Contains(character))
                    continue;
                filteredText += character.ToString();
            }

            string projectKey = "";
            if (filteredText.Contains(" "))
            {
                string[] arrayText = filteredText.Split(' ');
                foreach (var item in arrayText)
                {
                    if (item.Length < 1)
                        continue;
                    projectKey += item.Substring(0, 1);
                }
            }
            else
            {
                projectKey = filteredText;
            }

            var trimLength = (projectKey.Length > 4 ? 4 : projectKey.Length);
            projectKey = projectKey.Substring(0, trimLength);

            return projectKey.ToUpper();
        }

        #endregion

        protected void Txt_ProjectTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_ProjectTitle.Text.Trim()))
                    return;

                string text = Txt_ProjectTitle.Text.Trim();

                Txt_ProjectKey.Text = GenerateProjectKey(text);
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
                ShowSuccess("Your project has been initiated successfully.");
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