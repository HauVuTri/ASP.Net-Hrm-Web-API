using HRMAspNet.Common;
using HRMAspNet.Models;
using HRMAspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface IAdministrativeArea
    {
        Task<Aministrativearea> GetAministrativeareaByCode(string administrativeAreaCode);
        Task<ActionServiceResult> GetAdministrativeByParentCode(int codeDetect, int parentCode);
    }
}
