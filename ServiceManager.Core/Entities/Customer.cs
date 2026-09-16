using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Linking the Customer to the ApplicationUser (for login details)
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
        // A customer can have multiple service addresses
        public ICollection<ServiceAddress> Addresses { get; set; } = new List<ServiceAddress>();

        // A customer can raise multiple service requests
        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
    }
}
