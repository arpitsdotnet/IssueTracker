using System.Linq;
using System.Web.Http;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;

namespace IssueTracker.WebAPI.Controllers
{    
    public class ProjectApiController : ApiController
    {
        private readonly ProjectController _projectController;

        public ProjectApiController(ProjectController projectController)
        {
            _projectController = projectController;
        }
        public ProjectApiController() : this(
            new ProjectController())
        {
        }

        // GET api/<controller>
        //[HttpGet]
        //[Route("api/<controller>")]
        //public IHttpActionResult Get([FromUri]GetProjectRequest request)
        //{
        //    ResultList<Project> result = _projectController.GetProjects(request);

        //    if (result.HasValue)
        //        return Ok(new { Message = result.Message, Data = result.Data.FirstOrDefault(), RecordCount = result.RecordCount });

        //    return BadRequest(result.Message);
        //}

        // GET api/<controller>/projectKey
        [HttpGet]
        [Route("api/<controller>/projectkey")]
        public IHttpActionResult GetProjectKey(string key)
        {
            ResultList<string> result = _projectController.GenerateProjectKey(key);

            if (result.HasValue)
                return Ok(new { ProjectKey = result.Data.FirstOrDefault() });

            return BadRequest(result.Message);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] AddProjectRequest request)
        {
            ResultList<Project> result = _projectController.CreateProject(request);

            if (result.HasValue)
                return Ok(new { Message = result.Message, Data = result.Data.FirstOrDefault() });

            return BadRequest(result.Message);
        }

        // PUT api/<controller>/5
        //public IHttpActionResult Put(int id, [FromBody] UpdateProjectRequest request)
        //{
        //    ResultList<Project> result = _projectController.UpdateProject(id, request);

        //    if (result.HasValue)
        //        return Ok(result.Data.FirstOrDefault());

        //    return BadRequest(result.Message);
        //}

        // DELETE api/<controller>/5
        //public IHttpActionResult Delete(int id, [FromBody] DeleteProjectRequest request)
        //{
        //    ResultList<Project> result = _projectController.DeleteProject(id, request);

        //    if (result.HasValue)
        //        return Ok(result.Data.FirstOrDefault());

        //    return BadRequest(result.Message);
        //}
    }
}