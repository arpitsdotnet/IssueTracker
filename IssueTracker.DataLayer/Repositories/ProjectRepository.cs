using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;

namespace IssueTracker.DataLayer.Repositories
{
    public interface IProjectRepository
    {
        ResultList<Project> GetProjects(GetProjectRequest request);
        ResultSingle<Project> SaveProject(AddProjectRequest request);
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

        public ResultSingle<Project> SaveProject(AddProjectRequest request)
        {
            var result = _dBContext.SaveData<int>("spu_Project", request);

            return new ResultSingle<Project>(result.IsSuccess) { Message = result.Message, Data = new Project { ProjId = result.Data } };
        }

    }
}
