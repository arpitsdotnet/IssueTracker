using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Features.Projects.CreateProject;
using IssueTracker.BusinessLayer.Features.Projects.CreateProjectKey;
using IssueTracker.BusinessLayer.Features.Projects.Models;

namespace IssueTracker.WebAPI.Controllers
{
    public class ProjectApiController : ApiController
    {
        private readonly CreateProjectKeyController _createProjectKeyController;
        private readonly CreateProjectController _createProjectController;

        public ProjectApiController()
        {
            _createProjectKeyController = new CreateProjectKeyController();
            _createProjectController = new CreateProjectController();
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
            var result = _createProjectKeyController.Handle(new CreateProjectKeyRequest { ClientUID = "", SessionUID = "", Text = key });

            if (result.IsSuccess)
                return Ok(new { ProjectKey = result.Value.Key });

            return BadRequest(result.Message);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody] CreateProjectRequest request)
        {
            ResultList<Project> result = await _createProjectController.Handle(request);

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