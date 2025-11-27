using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.Projects.UpdateProject
{
    public class UpdateProjectRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public UpdateProjectRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<Project>> Handle(UpdateProjectRequest request)
        {
            var result = await _dBContext.SaveDataAsync("spu_Project", request);

            return new ResultList<Project>(result.HasValue) { Message = result.Message, Data = new List<Project>() { new Project { ProjId = Convert.ToInt32(result.Data) } } };
        }

    }
}
