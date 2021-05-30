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

        public int wardCode { get; set; }
        public string wardName { get; set; }
        public int districtCode { get; set; }
        public string districtName { get; set; }

        public WardAdministrativeAreaResponse(int wardCode, string wardName, int districtCode, string districtName)
        {
            this.wardCode = wardCode;
            this.wardName = wardName;
            this.districtCode = districtCode;
            this.districtName = districtName;
        }
    }
}
