using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.SysSubCategories.Dtos
{
    public class GetSubCategoryRequest
    {
        private GetSubCategoryRequest() { }

        public string ClientUID { get; private set; }
        public string SessionUID { get; private set; }
        public int CategoryId { get; set; }
        public static GetSubCategoryRequest Create(
            string ClientUID,
            string SessionUID,
            int CategoryId = 0)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);

            return new GetSubCategoryRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                CategoryId = CategoryId
            };
        }
    }
}
