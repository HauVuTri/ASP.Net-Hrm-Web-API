using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMAspNet.Models
{
    /// <summary>
    /// Lớp địa bàn hành chính
    /// </summary>
    public partial class Aministrativearea
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid AdministrativeAreaId { get; set; }
        /// <summary>
        /// Mã địa bàn hành chính
        /// </summary>
        public string AdministrativeAreaCode { get; set; }

        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public int ProvincialCode { get; set; }
        
        /// <summary>
        /// Tên tỉnh
        /// </summary>
        public string ProvincialName { get; set; }

        /// <summary>
        /// Mã Quận/Huyện
        /// </summary>
        public int DistrictCode { get; set; }

        /// <summary>
        /// Tên Quận/Huyện
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// Mã xã,phường
        /// </summary>
        public int WardCode { get; set; }
        
        /// <summary>
        /// Tên xã,phường
        /// </summary>
        public string WardName { get; set; }
    }
}
