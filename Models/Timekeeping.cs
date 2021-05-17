using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    public partial class Timekeeping
    {
        public Guid TimeKeepingId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime Period { get; set; }
    }
}
