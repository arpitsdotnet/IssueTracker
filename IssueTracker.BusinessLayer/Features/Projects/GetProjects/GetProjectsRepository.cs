using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Features.Projects.GetProjects;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

public class GetProjectsRepository
{
    public readonly IApplicationDBContext _dBContext;

    public GetProjectsRepository()
    {
        _dBContext = DbContextFactory.Instance;
    }

    public async Task<ResultList<Project>> Handle(GetProjectsRequest request)
    {
        var result = await _dBContext.LoadDataAsync<GetProjectsRequest, Project>("sps_Projects", request);

        return result;
    }
}
