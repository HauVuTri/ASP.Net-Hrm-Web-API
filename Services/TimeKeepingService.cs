using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Services
{
    public class TimeKeepingService : ITimeKeeping
    {
        private readonly HRMContext _context;

        public TimeKeepingService(HRMContext contex)
        {
            _context = contex;
        }
        public Task<List<Timekeeping>> GetTimeKeepingIncludeEmployeeByTimeCode(string timeCode)
        {
            //return ;
            var data = _context.Timekeeping.Include(x => x.EmployeeDetail).Where(x => x.TimeCode == timeCode).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}
