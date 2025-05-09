﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.DataLayer;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Projects.Dtos;
using IssueTracker.ModelLayer.Projects.Models;
using Moq;
using Xunit;

namespace IssueTracker.BusinessLayer.Tests.UnitTests.Controllers
{
    public class ProjectControllerTests : CommonController
    {
        private ProjectController _sut;

        public ProjectControllerTests()
        {
        }

        [Fact]
        public void GetProjectRequest_ShouldReturnResultWithError_WhenClientUidIsBlank()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
                    ClientUID: "",
                    SessionUID: ""
            ));
        }

        [Fact]
        public void GetProjectRequest_ShouldReturnResultWithError_WhenClientUidIsNotGuid()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
                    ClientUID: "1",
                    SessionUID: ""
            ));
        }

        [Fact]
        public void GetProjectRequest_ShouldReturnResultWithError_WhenSessionUidIsBlank()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
                    ClientUID: Guid.NewGuid().ToString(),
                    SessionUID: ""
            ));
        }

        [Fact]
        public void GetProjectRequest_ShouldReturnResultWithError_WhenSessionUidIsNotGuid()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<FieldValidationException>(() => GetProjectRequest.Create(
                    ClientUID: Guid.NewGuid().ToString(),
                    SessionUID: "1"
            ));
        }

        [Fact]
        public void GetProjectRequest_ShouldReturnResultWithSuccess_WhenValidClientUidAndSessionUidIsPasses()
        {
            // Arrange
            var clientUid = Guid.NewGuid().ToString();
            var sessionUid = Guid.NewGuid().ToString();

            // Act
            var sut = GetProjectRequest.Create(
                    ClientUID: clientUid,
                    SessionUID: sessionUid
            );

            // Assert
            Assert.IsType<GetProjectRequest>(sut);
            Assert.Equal(sut.ClientUID, clientUid);
            Assert.Equal(sut.SessionUID, sessionUid);
            Assert.Equal(sut.ProjectId, 0);
        }

        [Fact]
        public void GetProjects_ShouldReturnResultWithSuccess_WhenCalled()
        {
            // Arrange
            var clientUid = Guid.NewGuid().ToString();
            var sessionUid = Guid.NewGuid().ToString();

            var projects = new List<Project>();

            projects.Add(new Project
            {
                ClientUID = clientUid,
                ProjId = 1,
                ProjTitle = "Test",
                ProjKey = "TEST-1"
            });
            projects.Add(new Project
            {
                ClientUID = clientUid,
                ProjId = 2,
                ProjTitle = "Test2",
                ProjKey = "TEST2-2"
            });

            var expected = new ResultList<Project>(true)
            {
                Message = "Success.",
                Data = projects
            };

            var request = GetProjectRequest.Create(
                    ClientUID: clientUid,
                    SessionUID: sessionUid
            );

            var repository = new Mock<IProjectRepository>();
            repository.Setup(x => x.GetProjects(request)).Returns(expected);

            // Act
            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), repository.Object);
            var result = _sut.GetProjects(request);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateProjectKey_ShouldRemoveSpecialCharacters()
        {
            // Arrange
            var text = "Proj!ect@123";
            var expected = new List<string> { "PROJ" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }

        [Fact]
        public void GenerateProjectKey_ShouldCreateKeyFromFirstLetters()
        {
            // Arrange
            var text = "Project Key Example";
            var expected = new List<string> { "PKE" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }

        [Fact]
        public void GenerateProjectKey_ShouldHandleSingleWord()
        {
            // Arrange
            var text = "Project";
            var expected = new List<string> { "PROJ" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }

        [Fact]
        public void GenerateProjectKey_ShouldReturnUpperCase()
        {
            // Arrange
            var text = "project key";
            var expected = new List<string> { "PK" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }

        [Fact]
        public void GenerateProjectKey_ShouldTrimToMaxLength()
        {
            // Arrange
            var text = "Short";
            var expected = new List<string> { "SHOR" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }

        [Fact]
        public void GenerateProjectKey_ShouldHandleEmptyInput()
        {
            // Arrange
            var text = "";
            var expected = new List<string> { "" };

            _sut = new ProjectController(It.IsAny<ILogger<ProjectController>>(), It.IsAny<ICacheClient>(), It.IsAny<IProjectRepository>());

            // Act
            var result = _sut.GenerateProjectKey(text);

            // Assert
            Assert.Equal(true, result.HasValue);
            Assert.Equal(expected, result.Data);
        }
    }
}
