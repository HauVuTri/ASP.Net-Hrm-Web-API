using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMAspNet.Models;
using HRMAspNet.Controllers.BaseController;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Interfaces;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimekeepingsController : BaseController<Timekeeping>
    {
        private readonly ITimeKeeping _timeKeeping;


        public TimekeepingsController(IBase<Timekeeping> iBase, ITimeKeeping timeKeeping) : base(iBase)
        {
            _timeKeeping = timeKeeping;
        }
        /// <summary>
        /// Lấy thông tin chấm công của các nhân viên dựa theo timeCode
        /// timeCode dạng: mm/YYYY
        /// </summary>
        /// <param name="timeCode"></param>
        /// <returns></returns>
        [HttpGet("GetTimeKeepingIncludeEmployeeByTimeCode")]
        public async Task<List<Timekeeping>> GetTimeKeepingIncludeEmployeeByTimeCode(string timeCode)
        {
            return await _timeKeeping.GetTimeKeepingIncludeEmployeeByTimeCode(timeCode);
        }
    }
}
