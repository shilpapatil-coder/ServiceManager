using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public class Technician
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Linking the Technician to the ApplicationUser
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
        // Tracking technician availability and workload
        public bool IsAvailable { get; set; } = true;
        public int CurrentWorkload { get; set; } = 0; // Number of active jobs
        // A technician can be assigned to multiple jobs
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
