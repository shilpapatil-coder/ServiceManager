using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public enum ServiceRequestStatus
    {
        Raised = 1,
        Assigned = 2,
        TechnicianOnTheWay = 3,
        InProgress = 4,
        Completed = 5,
        Closed = 6,
        Rejected = 7
    }
}
