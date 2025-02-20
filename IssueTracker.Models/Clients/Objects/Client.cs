using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.ModelLayer.Clients.Objects
{
    public class Client
    {
        public string ClientUID { get; set; }
        public string ClientName { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string PrimaryContactEmail { get; set; }

    }
}
