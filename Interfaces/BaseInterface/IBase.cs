using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces.BaseInterface
{
    public interface IBase<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> GetAllEntities();

    }
}
