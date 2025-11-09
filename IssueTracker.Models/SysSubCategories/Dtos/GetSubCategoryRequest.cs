using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.SysSubCategories.Dtos
{
    public class GetSubCategoryRequest
    {
        private GetSubCategoryRequest() { }

        public string ClientUID { get; private set; }
        public string SessionUID { get; private set; }
        public int CategoryId { get; set; }
        public string CategoryKey { get; set; }

        public static GetSubCategoryRequest CreateObject(
            string ClientUID,
            string SessionUID,
            int CategoryId = 0,
            string CategoryKey = "")
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);

            return new GetSubCategoryRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                CategoryId = CategoryId,
                CategoryKey = CategoryKey
            };
        }

        public static GetSubCategoryRequest CreateRowStatusObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.ROW_STATUS);
        public static GetSubCategoryRequest CreateProjectStatusObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.PROJECT_STATUS);
        public static GetSubCategoryRequest CreateProjectTypeObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.PROJECT_TYPE);
        public static GetSubCategoryRequest CreateProjectCategoryObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.PROJECT_CATEGORY);
        public static GetSubCategoryRequest CreateProjectTemplateObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.PROJECT_TEMPLATE);
        public static GetSubCategoryRequest CreateIssueStatusObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.ISSUE_STATUS);
        public static GetSubCategoryRequest CreateIssueTypeObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.ISSUE_TYPE);
        public static GetSubCategoryRequest CreateIssuePriorityObject(string ClientUID, string SessionUID) => CreateObject(ClientUID, SessionUID, CategoryKey: CategoryKeys.ISSUE_PRIORITY);

    }
}
