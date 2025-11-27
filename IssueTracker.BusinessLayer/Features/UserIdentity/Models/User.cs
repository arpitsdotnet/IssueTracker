
using IssueTracker.BusinessLayer.Constants;

namespace IssueTracker.BusinessLayer.Features.UserIdentity.Models
{
    public class User
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string LastModifiedOn { get; set; }
        public RowStatuses RowStatus { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public short UserRoleId { get; set; } // ADMINISTRATOR | MANAGER | TEAM LEAD | SCRUM MASTER | DEVELOPER | TESTER | DESIGNER
        public string UserRoleCode { get; set; } // ADMINISTRATOR | MANAGER | TEAM LEAD | SCRUM MASTER | DEVELOPER | TESTER | DESIGNER
        public string OTP { get; set; }
        public string OTPExpiryTime { get; set; }
        public string OTPInvalidCount { get; set; }
        public string ProfileFilePath { get; set; }
    }
}