using System;
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
            var data = _dBContext.LoadData<GetProjectRequest, Project>("spProject_Get", projectRequest);

            return data;
        }
        public ResultSingle<Project> SaveProject(CreateProjectRequest projectRequest)
        {
            var data = _dBContext.SaveData<Int32>("spProject_Save", projectRequest);

            return new ResultSingle<Project> { IsSuccess = data.IsSuccess, Message = data.Message, Data = new Project { ProjectId = data.Data } };
        }
    }
}
