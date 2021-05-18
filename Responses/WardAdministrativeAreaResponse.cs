using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Responses
{
    public class WardAdministrativeAreaResponse
    {
        public WardAdministrativeAreaResponse()
        {
        }

        public int provincialCode { get; set; }
        public string provincialName { get; set; }
        public int districtCode { get; set; }
        public string districtName { get; set; }

        public WardAdministrativeAreaResponse(int provincialCode, string provincialName, int districtCode, string districtName)
        {
            this.provincialCode = provincialCode;
            this.provincialName = provincialName;
            this.districtCode = districtCode;
            this.districtName = districtName;
        }
    }
}
