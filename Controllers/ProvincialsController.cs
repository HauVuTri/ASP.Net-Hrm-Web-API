using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMAspNet.Models;
using HRMAspNet.Interfaces;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Controllers.BaseController;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincialsController : BaseController<Provincial>
    {
        public ProvincialsController(IBase<Provincial> iBase) : base(iBase)
        {
        }
    }
}
