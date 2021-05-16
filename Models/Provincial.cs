using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    public partial class Provincial
    {
        public Guid ProvincialId { get; set; }
        public int ProvincialCode { get; set; }
        public string ProvincialName { get; set; }
    }
}
