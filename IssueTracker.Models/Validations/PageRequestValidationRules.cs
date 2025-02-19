using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Validations
{
    public class PageRequestValidationRules
    {
        public static void Validate(int PageNo, short PageSize)
        {
            if (PageNo <= 0)
                throw new FieldValidationException("Required!", "Page No must not be negative or zero.");
            if (PageSize <= 0)
                throw new FieldValidationException("Required!", "Page Size must not be negative or zero.");
            if (PageSize > 1000)
                throw new FieldValidationException("Required!", "Page Size must not be greater than 1000.");
        }
    }
}
