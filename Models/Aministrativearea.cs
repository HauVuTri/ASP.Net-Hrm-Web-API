using System;
using System.Collections.Generic;

namespace HRMAspNet.Models
{
    public partial class Aministrativearea
    {
        public Guid AdministrativeAreaId { get; set; }
        public string AdministrativeAreaCode { get; set; }
        public int ProvincialCode { get; set; }
        public string ProvincialName { get; set; }
        public int DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public int WardCode { get; set; }
        public string WardName { get; set; }
    }
}
