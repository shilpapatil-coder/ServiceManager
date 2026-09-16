using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public class ServiceRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ProblemDescription { get; set; } = string.Empty;
        public DateTime PreferredServiceTime { get; set; }
        public ServiceRequestStatus Status { get; set; } = ServiceRequestStatus.Raised;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Foreign Keys
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public Guid ServiceAddressId { get; set; }
        public ServiceAddress? ServiceAddress { get; set; }
        // A request can have an assignment (when a technician is assigned)
        public Assignment? Assignment { get; set; }
    }
}
