using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Features.Projects.CreateProject;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using Moq;
using Xunit;

namespace IssueTracker.BusinessLayer.UnitTests.Controllers
{
    public class ProjectControllerTests : CommonController
    {
        //private readonly Mock<ILogger<CreateProjectController>> _loggerMock;
        //private readonly Mock<ICacheClient> _cacheClientMock;
        //private readonly Mock<GetProjectsRepository> _projectRepoMock;
        //private CreateProjectController _controller;

        public ProjectControllerTests()
        {
            //_loggerMock = new Mock<ILogger<CreateProjectController>>();
            //_cacheClientMock = new Mock<ICacheClient>();
            //_projectRepoMock = new Mock<GetProjectsRepository>();

            //_controller = new ProjectController(_loggerMock.Object, _cacheClientMock.Object, _projectRepoMock.Object);
        }

        //[Fact]
        //public async Task GetProjects_ShouldReturnData()
        //{
        //    // Arrange
        //    var clientUid = Guid.NewGuid().ToString();
        //    var sessionUid = Guid.NewGuid().ToString();
        //    int projectId = 123;
        //    var request = GetProjectRequest.Create(clientUid, sessionUid, projectId);
        //    var projects = new ResultList<Project>(true) { Data = new List<Project> { new Project() { ProjId = projectId } } };
        //    _projectRepoMock.Setup(repo => repo.GetProjects(request)).Returns(projects);

        //    // Act
        //    var result = await _controller.Handle(request);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.True(result.HasValue);
        //    Assert.Single(result.Data);
        //}

        //[Fact]
        //public void GetProjects_ShouldReturnResultWithSuccess_WhenCalled()
        //{
        //    // Arrange
        //    var clientUid = It.IsAny<string>();
        //    var sessionUid = It.IsAny<string>();

        //    var projects = new List<Project>();

        //    projects.Add(new Project
        //    {
        //        ClientUID = clientUid,
        //        ProjId = 1,
        //        ProjTitle = "Test",
        //        ProjKey = "TEST-1"
        //    });
        //    projects.Add(new Project
        //    {
        //        ClientUID = clientUid,
        //        ProjId = 2,
        //        ProjTitle = "Test2",
        //        ProjKey = "TEST2-2"
        //    });

        //    var expected = new ResultList<Project>(true)
        //    {
        //        Message = "Success.",
        //        Data = projects
        //    };

        //    var request = GetProjectRequest.Create(
        //            ClientUID: clientUid,
        //            SessionUID: sessionUid
        //    );

        //    var repository = new Mock<IProjectRepository>();
        //    repository.Setup(x => x.GetProjects(request)).Returns(expected);

        //    // Act
        //    _controller = new ProjectController(_loggerMock.Object, _cacheClientMock.Object, repository.Object);
        //    var result = _controller.GetProjects(request);

        //    // Assert
        //    Assert.Equal(expected.HasValue, result.HasValue);
        //    Assert.Equal(expected.Data.First().ProjId, result.Data.First().ProjId);
        //}


        //[Fact]
        //public void GetProjectRequest_ShouldReturnResultWithError_WhenClientUidIsBlank()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
        //            ClientUID: "",
        //            SessionUID: ""
        //    ));
        //}

        //[Fact]
        //public void GetProjectRequest_ShouldReturnResultWithError_WhenClientUidIsNotGuid()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
        //            ClientUID: "1",
        //            SessionUID: ""
        //    ));
        //}

        //[Fact]
        //public void GetProjectRequest_ShouldReturnResultWithError_WhenSessionUidIsBlank()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
        //            ClientUID: Guid.NewGuid().ToString(),
        //            SessionUID: ""
        //    ));
        //}

        //[Fact]
        //public void GetProjectRequest_ShouldReturnResultWithError_WhenSessionUidIsNotGuid()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
        //            ClientUID: Guid.NewGuid().ToString(),
        //            SessionUID: "1"
        //    ));
        //}

        //[Fact]
        //public void GetProjectRequest_ShouldReturnResultWithSuccess_WhenValidClientUidAndSessionUidIsPasses()
        //{
        //    // Arrange
        //    var clientUid = Guid.NewGuid().ToString();
        //    var sessionUid = Guid.NewGuid().ToString();

        //    // Act
        //    var sut = GetProjectRequest.Create(
        //            ClientUID: clientUid,
        //            SessionUID: sessionUid
        //    );

        //    // Assert
        //    Assert.IsType<GetProjectRequest>(sut);
        //    Assert.Equal(sut.ClientUID, clientUid);
        //    Assert.Equal(sut.SessionUID, sessionUid);
        //    Assert.Equal(sut.ProjectId, 0);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldRemoveSpecialCharacters()
        //{
        //    // Arrange
        //    var text = "Proj!ect@123";
        //    var expected = new List<string> { "PROJ" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldCreateKeyFromFirstLetters()
        //{
        //    // Arrange
        //    var text = "Project Key Example";
        //    var expected = new List<string> { "PKE" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldHandleSingleWord()
        //{
        //    // Arrange
        //    var text = "Project";
        //    var expected = new List<string> { "PROJ" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldReturnUpperCase()
        //{
        //    // Arrange
        //    var text = "project key";
        //    var expected = new List<string> { "PK" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldTrimToMaxLength()
        //{
        //    // Arrange
        //    var text = "Short";
        //    var expected = new List<string> { "SHOR" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}

        //[Fact]
        //public void GenerateProjectKey_ShouldHandleEmptyInput()
        //{
        //    // Arrange
        //    var text = "";
        //    var expected = new List<string> { "" };

        //    _controller = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

        //    // Act
        //    var result = _controller.GenerateProjectKey(text);

        //    // Assert
        //    Assert.Equal(true, result.HasValue);
        //    Assert.Equal(expected, result.Data);
        //}
    }
}
