using System;
using System.Linq;
using IssueTracker.DataLayer;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Objects;
using IssueTracker.ModelLayer.Projects.Requests;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class ProjectController : CommonController
    {
        private readonly IApplicationDBContext _dBContext;
        public ProjectController()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Project> GetProjects(GetProjectRequest projectRequest)
        {
            var validationResult = projectRequest.Validate();

            if (validationResult.IsSuccess == false)
                return validationResult;

            var data = _dBContext.LoadData<GetProjectRequest, Project>("sps_Projects", projectRequest);

            return data;
        }

        public ResultSingle<Project> SaveProject(CreateProjectRequest projectRequest)
        {
            var validationResult = projectRequest.Validate();

            if (validationResult.IsSuccess == false)
                return validationResult;

            var data = _dBContext.SaveData<int>("spu_Project", projectRequest);

            return new ResultSingle<Project>(data.IsSuccess) { Message = data.Message, Data = new Project { ProjId = data.Data } };
        }

        public string GenerateProjectKey(string text)
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
    }
}
