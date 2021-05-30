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
    public class NationalitiesController : BaseController<Nationality>
    {
        public NationalitiesController(IBase<Nationality> iBase) : base(iBase)
        {
        }
    }
}
