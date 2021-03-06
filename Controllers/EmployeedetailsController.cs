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

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeedetailsController : BaseController<Employeedetail>
    {
        public EmployeedetailsController(IBase<Employeedetail> iBase) : base(iBase)
        {
        }
    }
}
