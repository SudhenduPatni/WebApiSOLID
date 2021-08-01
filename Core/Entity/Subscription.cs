using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Subscription
    {
        public Guid ClientGlobalId { get; set; }
        public bool Subscribed { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double Charges { get; set; }
    }
}
