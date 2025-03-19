using System.Linq;
using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;
using IssueTracker.ModelLayer.Projects.Objects;
using IssueTracker.ModelLayer.Projects.Requests;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class ProjectController : CommonController
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository = null)
        {
            _projectRepository = projectRepository ?? new ProjectRepository();
        }

        public ResultList<Project> GetProjects(GetProjectRequest request)
        {
            var result = _projectRepository.GetProjects(request);

            return result;
        }

        public ResultSingle<Project> CreateProject(AddProjectRequest request)
        {
            var result = _projectRepository.SaveProject(request);

            if (result.IsSuccess == true)
            {
                var sessionUId = request.SessionUID;

                // Create the message service
                var messageService = new MessageService();

                // Create listeners
                var emailNotifier = new EmailNotifier();
                var smsNotifier = new SmsNotifier();

                // Subscribe to the event
                messageService.MessageSent += emailNotifier.OnMessageSent;
                messageService.MessageSent += smsNotifier.OnMessageSent;

                messageService.SendMessage(
                    sessionUId, 
                    $"Congratulation! Your project { request.ProjTitle } has been created.", 
                    $"Dear User! Your project { request.ProjTitle } has been created."
                ).GetAwaiter().GetResult();

            }

            return result;
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
