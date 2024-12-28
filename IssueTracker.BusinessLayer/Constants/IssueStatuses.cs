﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.BusinessLayer.Constants
{
    public class IssueStatuses
    {
        public const char CREATED = 'C';
        public const char SUBMITTED = 'S';
        public const char APPROVED = 'A';
        public const char REJECTED = 'R';
        public const char DELETED = 'D';
    }
}