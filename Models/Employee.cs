using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    /// <summary>
    /// Lớp người lao động
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// KHóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public string BirthDay { get; set; }

        /// <summary>
        /// Tên loại hợp đồng
        /// </summary>
        public string ContractTypeName { get; set; }

        /// <summary>
        /// Mã lao động
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Id trạng thái lao động
        /// </summary>
        public int? EmployeeStatusId { get; set; }
        public string EmployeeStatusName { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string HeallthnsuranceNumber { get; set; }
        public string HireDate { get; set; }
        public string InsuranceRate { get; set; }
        public int? JobPositionId { get; set; }
        public string JobPositionName { get; set; }
        public string Mobile { get; set; }
        public string OfficeEmail { get; set; }
        public string ReceiveDate { get; set; }
        public string SocialInsuranceCode { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public int? StatusId { get; set; }
        public int? SupervisorId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
