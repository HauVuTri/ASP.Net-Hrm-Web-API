using HRMAspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Controllers.Base
{
    [ApiController]
    public class BaseEFController<T> : ControllerBase
    {
        public HRMContext _context;

        //public BaseEFController(HRMContext context)
        //{
        //    _context = context;
        //}
        [HttpGet]
        public List<T> GetAllEntities<T>() where T: class
        {
            return (this._context.Set<T>().ToList());
        }
    }
}
