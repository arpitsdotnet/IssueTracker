using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ModelLayer
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public Int16 UserRoleId { get; set; } // ADMINISTRATOR | MANAGER | TEAM LEAD | SCRUM MASTER | DEVELOPER | TESTER | DESIGNER
        public string OTP { get; set; } 
        public string OTPExpiryTime { get; set; } 
        public string OTPInvalidCount { get; set; }

        public bool IsActive { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedOn { get; set; }
        public int LastModifiedByUserId { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}