using HRMAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface ITimeKeeping
    {
        /// <summary>
        /// Lấy thông tin chấm công của các nhân viên dựa theo timeCode
        /// timeCode dạng: mm/YYYY
        /// </summary>
        /// <param name="timeCode"></param>
        /// <returns></returns>
        Task<List<Timekeeping>> GetTimeKeepingIncludeEmployeeByTimeCode(string timeCode);
        Task<bool> CalculateTimeKeeping(string timeCode);
        Task<List<int>> GetNumberOfEmployeeLateInMonth(string timeCode);
    }
}
