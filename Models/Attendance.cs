using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    public partial class Attendance
    {
        public Guid AttendanceId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
    }
}
