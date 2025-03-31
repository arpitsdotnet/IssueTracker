using System;
using System.Collections.Generic;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;

namespace IssueTracker.DataLayer.Repositories
{
    public interface IProjectRepository
    {
        ResultList<Project> GetProjects(GetProjectRequest request);
        ResultList<Project> SaveProject(AddProjectRequest request);
    }

    public class ProjectRepository : IProjectRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public ProjectRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Project> GetProjects(GetProjectRequest request)
        {
            var result = _dBContext.LoadData<GetProjectRequest, Project>("sps_Projects", request);

            return result;
        }

        public ResultList<Project> SaveProject(AddProjectRequest request)
        {
            var result = _dBContext.SaveData("spu_Project", request);

            return new ResultList<Project>(result.HasValue) { Message = result.Message, Data = new List<Project>() { new Project { ProjId = Convert.ToInt32(result.Data) } } };
        }

    }
}
