using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMAspNet.Models;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private HRMContext _context;
        public EmployeeController(HRMContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IList<Employee> Get()
        {
            return (this._context.Employee.ToList());
        }
       
    }
}
