using HRMAspNet.Entities;
using HRMAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface IRollCall
    {
        public Task<List<RollCallResponse>> GetDataBySqlQuery(Guid rollCallId);
        Task<List<Rollcall>> GetRollCallIncludeEmployeeByTimeCode(string rollCallTimeCode);
        Task<bool> CreateRollCallFromFaceRecognize(Guid employeeDetailID, string rollCallTimeCode);
        Task<bool> CreateRollCallFromFaceRecognizeByEmployeeCode(string employeeCode, string rollCallTimeCode);
    }
}
