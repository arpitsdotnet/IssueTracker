using System;
using System.Collections.Generic;
using System.Linq;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.CacheService;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class ProjectController : CommonController
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ICacheClient _cacheClient;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(
            ILogger<ProjectController> logger,
            ICacheClient cacheClient,
            IProjectRepository projectRepository)
        {
            _logger = logger;
            _cacheClient = cacheClient;
            _projectRepository = projectRepository;
        }
        public ProjectController() : this(
            new FileLogger<ProjectController>(),
            new CacheClient(),
            new ProjectRepository())
        {
        }

        private string BuildCacheKey(int projectId)
        {
            return $"project:{projectId}";
        }

        public ResultList<Project> GetProjects(GetProjectRequest request)
        {
            _logger.Log("GetProjects.GetProjectRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                //var cacheResult = _cacheClient.Get<Project>(BuildCacheKey(request.ProjectId));
                //if (cacheResult.HasValue)
                //{
                //    return cacheResult;
                //}

                var result = _projectRepository.GetProjects(request);
                //_cacheClient.Set<Project>(BuildCacheKey(request.ProjectId), result);

                return result;
            });
        }

        public ResultList<Project> CreateProject(AddProjectRequest request)
        {
            _logger.Log("CreateProject.AddProjectRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                var result = _projectRepository.SaveProject(request);

                if (result.HasValue == true)
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

                //Form_Clear();

                return result;
            });
        }

        public ResultList<string> GenerateProjectKey(string text)
        {
            _logger.Log("GenerateProjectKey.text", text);
            return HandleBusinessException(_logger, () =>
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

                return new ResultList<string>(true) { Data = new List<string>() { projectKey.ToUpper() } };
            });
        }
    }
}
