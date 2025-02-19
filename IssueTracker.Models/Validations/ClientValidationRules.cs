using System;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.ModelLayer.Validations
{
    public class ClientValidationRules
    {
        public class ClientUID
        {
            public static void IsRequired(string ClientUID)
            {
                if (string.IsNullOrEmpty(ClientUID))
                    throw new FieldValidationException("Required!", "Client empty, please try re-login.");

                if (Guid.TryParse(ClientUID, out Guid result) == false)
                    throw new FieldValidationException("Invalid!", "Client is invalid, please try re-login.");
            }
        }
    }
}