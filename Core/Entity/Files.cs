using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Files
    {
        public Guid FileGlobalId { get; set; }
        public Guid ClientGlobalId { get; set; }
        public string Name { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
