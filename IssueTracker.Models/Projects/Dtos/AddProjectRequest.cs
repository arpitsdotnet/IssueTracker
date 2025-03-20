using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.Projects.Dtos
{
    public class AddProjectRequest
    {
        private AddProjectRequest() { }
        private AddProjectRequest(
            string SessionUID,
            string ProjKey,
            string ProjTitle,
            short ProjCategoryId,
            short ProjTemplateId,
            short ProjTypeId,
            string ProjIconUrl)
        {
            this.SessionUID = SessionUID;
            this.ProjKey = ProjKey;
            this.ProjTitle = ProjTitle;
            this.ProjCategoryId = ProjCategoryId;
            this.ProjTemplateId = ProjTemplateId;
            this.ProjTypeId = ProjTypeId;
            this.ProjIconUrl = ProjIconUrl;
            RowStatus = RowStatuses.APPROVED;
            ProjStatus = ProjectStatuses.NEW;
        }

        public string SessionUID { get; private set; }
        public string ProjKey { get; set; }
        public string ProjTitle { get; set; }
        public string ProjIconUrl { get; set; }
        public short ProjCategoryId { get; set; }
        public short ProjTemplateId { get; set; }
        public short ProjTypeId { get; set; }
        public RowStatuses RowStatus { get; private set; }
        public ProjectStatuses ProjStatus { get; private set; }

        public static AddProjectRequest Create(
            string SessionUID,
            string ProjKey,
            string ProjTitle,
            short ProjCategoryId,
            short ProjTemplateId,
            short ProjTypeId,
            string ProjIconUrl)
        {
            SessionValidationRules.SessionUID.IsRequired(SessionUID);

            ProjectValidationRules.ProjTitle.IsRequired(ProjTitle);
            ProjectValidationRules.ProjTitle.HasValidLength(ProjTitle);

            ProjectValidationRules.ProjKey.IsRequired(ProjKey);
            ProjectValidationRules.ProjKey.HasValidLength(ProjKey);

            ProjectValidationRules.ProjCategoryId.IsRequired(ProjCategoryId);

            ProjectValidationRules.ProjTemplateId.IsRequired(ProjTemplateId);

            ProjectValidationRules.ProjTypeId.IsRequired(ProjTypeId);

            ProjectValidationRules.ProjIconUrl.HasValidImage(ProjIconUrl);

            return new AddProjectRequest(
                SessionUID,
                ProjKey,
                ProjTitle,
                ProjCategoryId,
                ProjTemplateId,
                ProjTypeId,
                ProjIconUrl);
        }
    }
}
