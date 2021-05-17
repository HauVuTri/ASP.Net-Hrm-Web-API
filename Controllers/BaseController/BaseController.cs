using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Controllers.BaseController
{
    [ApiController]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBase<T> _iBase;

        public BaseController(IBase<T> iBase)
        {
            _iBase = iBase;
        }


        // GET: api/Aministrativeareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAllEntities()
        {
            return await _iBase.GetAllEntities();
        }
    }
}
