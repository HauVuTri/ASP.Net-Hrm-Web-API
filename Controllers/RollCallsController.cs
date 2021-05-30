using HRMAspNet.Controllers.BaseController;
using HRMAspNet.Entities;
using HRMAspNet.Interfaces;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Models;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    public class RollCallsController : BaseController<Rollcall>
    {
        private readonly IRollCall _iRollCall;

        public RollCallsController(IBase<Rollcall> iBase, IRollCall iRollCall) : base(iBase)
        {
            _iRollCall = iRollCall;
        }

        [HttpGet("GetDataBySqlQuery")]
        public async Task<List<RollCallResponse>> GetDataBySqlQuery(Guid rollCallId)
        {
            return await _iRollCall.GetDataBySqlQuery(rollCallId);
        }

        [HttpGet("GetRollCallIncludeEmployeeByTimeCode")]
        public async Task<List<Rollcall>> GetRollCallIncludeEmployeeByTimeCode(string rollCallTimeCode)
        {
            return await _iRollCall.GetRollCallIncludeEmployeeByTimeCode(rollCallTimeCode);
        }
        /// <summary>
        /// Tạo 1 bản ghi điểm danh với ID người lao đọng + rollcalltimecode
        /// </summary>
        /// <param name="employeeDetailID"></param>
        /// <param name="RollCallTimeCode"></param>
        /// <returns></returns>
        [HttpPost("CreateRollCallFromFaceRecognize")]
        public async Task<bool> CreateRollCallFromFaceRecognize(Guid employeeDetailID,string RollCallTimeCode)
        {
            return await _iRollCall.CreateRollCallFromFaceRecognize(employeeDetailID, RollCallTimeCode);
        }

        /// <summary>
        /// Tạo 1 bản ghi điểm dnah bằng MÃ LAO ĐỘNG + rollcalltimecode
        /// </summary>
        /// <param name="employeeDetailID"></param>
        /// <param name="RollCallTimeCode"></param>
        /// <returns></returns>
        [HttpPost("CreateRollCallFromFaceRecognizeByEmployeeCode")]
        public async Task<bool> CreateRollCallFromFaceRecognizeByEmployeeCode(string employeeCode, string RollCallTimeCode)
        {
            return await _iRollCall.CreateRollCallFromFaceRecognizeByEmployeeCode(employeeCode, RollCallTimeCode);
        }
    }
}
