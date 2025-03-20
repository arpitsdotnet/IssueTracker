﻿using IssueTracker.ModelLayer.Constants;
using IssueTracker.ModelLayer.Users.Models;

namespace IssueTracker.ModelLayer.SysSubCategories.Models
{
    public class SubCategory
    {
        public int SubcId { get; set; }
        public int CateId { get; set; }
        public string ClientUID { get; set; }
        public RowStatuses RowStatus { get; set; }
        public string CreatedOn { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public string ModifiedOn { get; set; }
        public int ModifierId { get; set; }
        public User Modifier { get; set; }
        public string SubcKey { get; set; }
        public string SubcTitle { get; set; }
        public string SubcIconUrl { get; set; }

    }
}
