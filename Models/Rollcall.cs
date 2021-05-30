using System;
using System.Collections.Generic;

namespace HRMAspNet.Models
{
    public partial class Rollcall
    {
        public Guid RollCallId { get; set; }
        public string RollCallTimeCode { get; set; }
        public Guid EmployeeDetailId { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime TimeCheckin { get; set; }
        public float LateTime { get; set; }

        public virtual Employeedetail EmployeeDetail { get; set; }

        public Rollcall(Guid rollCallId, string rollCallTimeCode, Guid employeeDetailId, string employeeCode, DateTime timeCheckin, float lateTime)
        {
            RollCallId = rollCallId;
            RollCallTimeCode = rollCallTimeCode;
            EmployeeDetailId = employeeDetailId;
            EmployeeCode = employeeCode;
            TimeCheckin = timeCheckin;
            LateTime = lateTime;
        }
    }
}
