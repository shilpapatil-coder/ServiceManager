using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; } = string.Empty;
        // Foreign Keys
        public Guid ServiceRequestId { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }
        public Guid TechnicianId { get; set; }
        public Technician? Technician { get; set; }
    }
}
