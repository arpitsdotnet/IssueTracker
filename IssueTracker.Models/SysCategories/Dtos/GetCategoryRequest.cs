using IssueTracker.ModelLayer.Validations;

namespace IssueTracker.ModelLayer.SysCategories.Dtos
{
    public class GetCategoryRequest
    {
        private GetCategoryRequest() { }

        public string ClientUID { get; private set; }
        public string SessionUID { get; private set; }
        public int CategoryId { get; set; }
        public static GetCategoryRequest Create(
            string ClientUID,
            string SessionUID,
            int CategoryId = 0)
        {
            ClientValidationRules.ClientUID.IsRequired(ClientUID);
            SessionValidationRules.SessionUID.IsRequired(SessionUID);

            return new GetCategoryRequest
            {
                ClientUID = ClientUID,
                SessionUID = SessionUID,
                CategoryId = CategoryId
            };
        }
    }
}
