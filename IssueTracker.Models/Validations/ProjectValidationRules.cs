using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Validations
{
    public class ProjectValidationRules
    {
        public class ProjectId
        {
            public static void IsRequired(int ProjectId)
            {
                if (ProjectId == 0)
                    throw new FieldValidationException("Required!", "Project is required, please select a valid value.");
            }
        }
        public class ProjTitle
        {
            public static void IsRequired(string ProjTitle)
            {
                if (string.IsNullOrEmpty(ProjTitle))
                    throw new FieldValidationException("Required!", "Project Title is required, please enter valid value.");
            }
            public static void HasValidLength(string ProjTitle)
            {
                if (string.IsNullOrEmpty(ProjTitle))
                    return;
                if (ProjTitle.Length < 3)
                    throw new FieldValidationException("Invalid!", "Project Title must be atleast 3 characters long.");
                if (ProjTitle.Length > 20)
                    throw new FieldValidationException("Invalid!", "Project Title must not be greater than 20 characters.");
            }
        }
        public class ProjKey
        {
            public static void IsRequired(string ProjKey)
            {
                if (string.IsNullOrEmpty(ProjKey))
                    throw new FieldValidationException("Required!", "Project Key is required, please enter valid value.");
            }
            public static void HasValidLength(string ProjKey)
            {
                if (string.IsNullOrEmpty(ProjKey))
                    return;
                if (ProjKey.Length < 2)
                    throw new FieldValidationException("Invalid!", "Project Key must be atleast 2 characters long.");
                if (ProjKey.Length > 10)
                    throw new FieldValidationException("Invalid!", "Project Key must not be greater than 10 characters.");
            }
        }
        public class ProjCategoryId
        {
            public static void IsRequired(int ProjCategoryId)
            {
                if (ProjCategoryId == 0)
                    throw new FieldValidationException("Required!", "Project Category is required, please select a valid value.");
            }
        }
        public class ProjTemplateId
        {
            public static void IsRequired(int ProjTemplateId)
            {
                if (ProjTemplateId == 0)
                    throw new FieldValidationException("Required!", "Project Template is required, please select a valid value.");
            }
        }
        public class ProjTypeId
        {
            public static void IsRequired(int ProjTypeId)
            {
                if (ProjTypeId == 0)
                    throw new FieldValidationException("Required!", "Project Type is required, please select a valid value.");
            }
        }
        public class ProjIconUrl
        {
            public static void IsRequired(string ProjIconUrl)
            {
                if (string.IsNullOrEmpty(ProjIconUrl))
                    throw new FieldValidationException("Required!", "Project Icon Url is required, please select valid image.");
            }
            public static void HasValidImage(string ProjIconUrl)
            {
                if (string.IsNullOrEmpty(ProjIconUrl))
                    return;
                if (ProjIconUrl.ToLower().Contains(".jpg?v=") == false &&
                    ProjIconUrl.ToLower().Contains(".jpeg?v=") == false &&
                    ProjIconUrl.ToLower().Contains(".png?v=") == false &&
                    ProjIconUrl.ToLower().Contains(".bmp?v=") == false &&
                    ProjIconUrl.ToLower().Contains(".webp?v=") == false)
                    throw new FieldValidationException("Invalid!", "Project Icon Type must be either *.jpg, *.jpeg, *.png, *.bmp, or *.webp.");
            }
        }
    }
}