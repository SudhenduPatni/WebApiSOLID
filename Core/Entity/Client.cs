using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public Guid ClientGlobalId { get; set; }
        public string Name { get; set; }
        public int CloudProviderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
