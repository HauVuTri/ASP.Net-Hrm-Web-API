using HRMAspNet.Controllers.Base;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Controllers
{
    [Route("api/user/")]
    public class UserController : BaseEFController<User>
    {
        public UserController(HRMContext context)
        {
            _context = context;
        }
    }
}
