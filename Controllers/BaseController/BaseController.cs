using HRMAspNet.Common;
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
    //[Authorize]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBase<T> _iBase;

        public BaseController(IBase<T> iBase)
        {
            _iBase = iBase;
        }


        // GET: api/Aministrativeareas
        [HttpGet]
        public async Task<ActionResult<List<T>>> GetAllEntities()
        {
            return await _iBase.GetAllEntities();
        }

        // GET: api/Aministrativeareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetEntityByID(Guid id)
        {
            return await _iBase.GetEntityByID(id);
        }

        // PUT: api/Aministrativeareas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> EditEntity(Guid id, T tEntity)
        {
            //return await _iAdministrativeArea.PutAministrativearea(id, aministrativearea);
            return await _iBase.ChangeAnEntityByID( id, tEntity);
        }

        // POST: api/Aministrativeareas
        [HttpPost]
        public async Task<ActionResult<bool>> CreateEntity(T tEntity)
        {
            return await _iBase.CreateEntity(tEntity);
        }

        /// <summary>
        /// Xóa 1 phần tử theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Aministrativeareas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEntỉtyByID(Guid id)
        {
            return await _iBase.DeleteEntỉtyByID(id);
            //var aministrativearea = await _context.Aministrativearea.FindAsync(id);
            //if (aministrativearea == null)
            //{
            //    return NotFound();
            //}

            //_context.Aministrativearea.Remove(aministrativearea);
            //await _context.SaveChangesAsync();

            //return aministrativearea;
        }
    }
}
