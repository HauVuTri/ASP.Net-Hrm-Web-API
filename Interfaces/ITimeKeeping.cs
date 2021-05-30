using HRMAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface ITimeKeeping
    {
        Task<List<Timekeeping>> GetTimeKeepingIncludeEmployeeByTimeCode(string timeCode);
    }
}
