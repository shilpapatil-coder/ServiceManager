using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Core.Entities
{
    public class ServiceAddress
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        // Linking back to the Customer
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
