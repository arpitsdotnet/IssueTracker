using System;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Controllers;
using Xunit;

namespace IssueTracker.BusinessLayer.UnitTests.Controllers
{
    public class IssueControllerTests
    {
        //private IssueController _sut;

        public IssueControllerTests()
        {
        }

        //[Fact]
        //public void GetIssueRequest_ShouldReturnResultWithError_WhenClientUidIsBlank()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetIssueRequest.Create(
        //            ClientUID: "",
        //            SessionUID: "",
        //            ProjectId: 0,
        //            IssueId: 0
        //    ));
        //}

        //[Fact]
        //public void GetIssueRequest_ShouldReturnResultWithError_WhenClientUidIsNotGuid()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetIssueRequest.Create(
        //            ClientUID: "1",
        //            SessionUID: "",
        //            ProjectId: 0,
        //            IssueId: 0
        //    ));
        //}

        //[Fact]
        //public void GetIssueRequest_ShouldReturnResultWithError_WhenSessionUidIsBlank()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetIssueRequest.Create(
        //            ClientUID: Guid.NewGuid().ToString(),
        //            SessionUID: "",
        //            ProjectId: 0,
        //            IssueId: 0
        //    ));
        //}

        //[Fact]
        //public void GetIssueRequest_ShouldReturnResultWithError_WhenSessionUidIsNotGuid()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //    Assert.Throws<FieldValidationException>(() => GetIssueRequest.Create(
        //            ClientUID: Guid.NewGuid().ToString(),
        //            SessionUID: "1",
        //            ProjectId: 0,
        //            IssueId: 0
        //    ));
        //}

        //[Fact]
        //public void GetIssueRequest_ShouldReturnResultWithSuccess_WhenValidClientUidAndSessionUidIsPasses()
        //{
        //    //// Arrange
        //    //var clientUid = Guid.NewGuid().ToString();
        //    //var sessionUid = Guid.NewGuid().ToString();

        //    //// Act
        //    //var sut = GetIssueRequest.Create(
        //    //        ClientUID: clientUid,
        //    //        SessionUID: sessionUid
        //    //);

        //    //// Assert
        //    //Assert.IsType<GetIssueRequest>(sut);
        //    //Assert.Equal(sut.ClientUID, clientUid);
        //    //Assert.Equal(sut.SessionUID, sessionUid);
        //    //Assert.Equal(sut.ProjectId, 0);
        //}

        //[Fact]
        //public void GetIssues_ShouldReturnResultWithSuccess_WhenCalled()
        //{
        //    //// Arrange
        //    //var clientUid = Guid.NewGuid().ToString();
        //    //var sessionUid = Guid.NewGuid().ToString();

        //    //var issues = new List<Issue>();

        //    //issues.Add(new Issue
        //    //{
        //    //    ClientUID = clientUid,
        //    //    SessionUID = sessionUid,
        //    //    ProjId = 1,
        //    //    ProjTitle = "Test",
        //    //    ProjKey = "TEST-1"
        //    //});
        //    //issues.Add(new Issue
        //    //{
        //    //    ClientUID = clientUid,
        //    //    SessionUID = sessionUid,
        //    //    ProjectId = 2,
        //    //    Project = new Project { ProjTitle = "Test2" },
        //    //    ProjKey = "TEST2-2"
        //    //});

        //    //var expected = new ResultList<Issue>(true)
        //    //{
        //    //    Message = "Success.",
        //    //    Data = issues
        //    //};

        //    //var request = GetIssueRequest.Create(
        //    //        ClientUID: clientUid,
        //    //        SessionUID: sessionUid,
        //    //        ProjectId: 1,
        //    //        IssueId: 1
        //    //);

        //    //var repository = new Mock<IIssueRepository>();
        //    //repository.Setup(x => x.GetIssues(request)).Returns(expected);

        //    //// Act
        //    //_sut = new IssueController(repository.Object);
        //    //var result = _sut.GetIssues(request);

        //    //// Assert
        //    //Assert.Equal(expected, result);
        //}
    }
}
