using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Services.BaseService
{
    public class BaseService<T> : IBase<T> where T : class
    {
        public async Task<ActionResult<IEnumerable<T>>> GetAllEntities()
        {
            using (HRMContext context = new HRMContext())
            {
                return await context.Set<T>().ToListAsync();
            }
            
            //return await _context.Aministrativearea.ToListAsync();
        }
    }
}
