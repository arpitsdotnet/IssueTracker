using System;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Validations
{
    public class SessionValidationRules
    {
        public class SessionUID
        {
            public static void IsRequired(string SessionUID)
            {
                if (string.IsNullOrEmpty(SessionUID))
                    throw new FieldValidationException("Required!", "Login expired, please try re-login.");

                if (Guid.TryParse(SessionUID, out Guid result) == false)
                    throw new FieldValidationException("Invalid!", "Login is invalid, please try re-login.");
            }
        }
    }
}