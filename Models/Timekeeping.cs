using System;
using System.Collections.Generic;

namespace HRMAspNet.Models
{
    public partial class Timekeeping
    {
        public Guid TimeKeepingId { get; set; }
        public Guid EmployeeDetailId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime Period { get; set; }
        public string TimeCode { get; set; }

        public virtual Employeedetail EmployeeDetail { get; set; }
    }
}
