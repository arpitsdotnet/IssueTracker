using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Validations
{
    public class IssueValidationRules
    {
        public class IssueId
        {
            public static void IsRequired(int IssueId)
            {
                if (IssueId == 0)
                    throw new FieldValidationException("Required!", "Issue is required, please select a valid value.");
            }
        }
        public class IssueTypeId
        {
            public static void IsRequired(short IssueTypeId)
            {
                if (IssueTypeId == 0)
                    throw new FieldValidationException("Required!", "Issue Type is required, please select a valid value.");
            }
        }
        public class IssueTitle
        {
            public static void IsRequired(string IssueTitle)
            {
                if (string.IsNullOrEmpty(IssueTitle))
                    throw new FieldValidationException("Required!", "Issue Title is required, please enter valid value.");
            }
            public static void HasValidLength(string IssueTitle)
            {
                if (string.IsNullOrEmpty(IssueTitle))
                    return;
                if (IssueTitle.Length < 3)
                    throw new FieldValidationException("Invalid!", "Issue Title must be atleast 3 characters long.");
                if (IssueTitle.Length > 50)
                    throw new FieldValidationException("Invalid!", "Issue Title must not be greater than 50 characters.");
            }
        }
        public class IssueKey
        {
            public static void IsRequired(string IssueKey)
            {
                if (string.IsNullOrEmpty(IssueKey))
                    throw new FieldValidationException("Required!", "Issue Key is required, please enter valid value.");
            }
            public static void HasValidLength(string IssueKey)
            {
                if (string.IsNullOrEmpty(IssueKey))
                    return;
                if (IssueKey.Length < 2)
                    throw new FieldValidationException("Invalid!", "Issue Key must be atleast 2 characters long.");
                if (IssueKey.Length > 10)
                    throw new FieldValidationException("Invalid!", "Issue Key must not be greater than 10 characters.");
            }
        }
    }
}