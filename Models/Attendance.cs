using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    /// <summary>
    /// Lớp điểm danh
    /// </summary>
    public partial class Attendance
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid AttendanceId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Thời gian checkin
        /// </summary>
        public DateTime CheckinTime { get; set; }
    }
}
