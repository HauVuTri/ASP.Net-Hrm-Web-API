using System;
using System.Collections.Generic;

namespace HRMAspNet.Models
{
    public partial class Provincial
    {
        public Guid ProvincialId { get; set; }
        public int ProvincialCode { get; set; }
        public string ProvincialName { get; set; }
    }
}
