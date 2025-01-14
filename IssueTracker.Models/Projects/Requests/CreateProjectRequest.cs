using System;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.Projects.Objects;

namespace IssueTracker.ModelLayer.Projects.Requests
{
    public class CreateProjectRequest
    {
        private CreateProjectRequest() { }
        private CreateProjectRequest(
            int SessionId,
            string ProjTitle,
            string ProjKey,
            short ProjCategoryId,
            short ProjTemplateId,
            short ProjTypeId,
            string ProjIconUrl)
        {
            this.SessionId = SessionId;
            this.ProjTitle = ProjTitle;
            this.ProjKey = ProjKey;
            this.ProjCategoryId = ProjCategoryId;
            this.ProjTemplateId = ProjTemplateId;
            this.ProjTypeId = ProjTypeId;
            this.ProjIconUrl = ProjIconUrl;
        }

        public int SessionId { get; private set; }
        public string ProjKey { get; set; }
        public string ProjTitle { get; set; }
        public string ProjIconUrl { get; set; }
        public short ProjCategoryId { get; set; }
        public short ProjTemplateId { get; set; }
        public short ProjTypeId { get; set; }
        public ProjectRowStatus RowStatus { get; private set; } = ProjectRowStatus.Open;

        public ResultSingle<Project> Validate()
        {
            if (SessionId == 0)
                return new ResultSingle<Project>(false) { Title = "Invalid!", Message = "Login is invalid, please try re-login." };

            if (string.IsNullOrEmpty(ProjTitle))
                return new ResultSingle<Project>(false) { Title = "Required!", Message = $"Please enter {nameof(ProjTitle)}." };
            if (ProjTitle.Length < 3)
                return new ResultSingle<Project>(false) { Title = "Invalid!", Message = $"{nameof(ProjTitle)} must be atleast 3 characters long." };
            if (ProjTitle.Length > 20)
                return new ResultSingle<Project>(false) { Title = "Invalid!", Message = $"{nameof(ProjTitle)} must not be greater than 20 characters." };

            if (string.IsNullOrEmpty(ProjKey))
                return new ResultSingle<Project>(false) { Title = "Required!", Message = $"Please enter {nameof(ProjKey)}." };
            if (ProjKey.Length < 2)
                return new ResultSingle<Project>(false) { Title = "Invalid!", Message = $"{nameof(ProjKey)} must be atleast 2 characters long." };
            if (ProjKey.Length > 10)
                return new ResultSingle<Project>(false) { Title = "Invalid!", Message = $"{nameof(ProjKey)} must not be greater than 10 characters." };

            return new ResultSingle<Project>(true);
        }

        public static CreateProjectRequest Generate(
            int SessionId,
            string ProjTitle,
            string ProjKey,
            short ProjCategoryId,
            short ProjTemplateId,
            short ProjTypeId,
            string ProjIconUrl) => 
            new CreateProjectRequest(
                SessionId,
                ProjTitle,
                ProjKey, 
                ProjCategoryId, 
                ProjTemplateId, 
                ProjTypeId, 
                ProjIconUrl);
    }
}
