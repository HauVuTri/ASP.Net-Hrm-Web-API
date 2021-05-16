using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMAspNet.Common;
using System.Net;

namespace HRMAspNet.Services
{
    public class AdministrativeAreaService : IAdministrativeArea
    {
        private readonly HRMContext _context;
        public AdministrativeAreaService(HRMContext context)
        {
            _context = context;
        }

        public Task<ActionResult<Administrativearea>> DeleteAministrativearea(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Administrativearea>>> GetAministrativearea()
        {
            return await _context.Aministrativearea.ToListAsync();
        }

        public async Task<ActionResult<Administrativearea>> GetAministrativearea(Guid id)
        {
            var aministrativearea = await _context.Aministrativearea.FindAsync(id);

            if (aministrativearea == null)
            {
                return NotFound();
            }

            return aministrativearea;
        }

        private ActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Administrativearea>> PostAministrativearea(Administrativearea aministrativearea)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<ActionServiceResult>> PutAministrativearea(Guid id, Administrativearea aministrativearea)
        {
            if (id != aministrativearea.AdministrativeAreaId)
            {
                return new ActionServiceResult((int)HttpStatusCode.BadRequest,false,"Bad Request");
            }

            _context.Entry(aministrativearea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!Common.AdministrativeareaExists(id))
                if (!CommonFunction.AdministrativeareaExists(id,_context))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new ActionServiceResult((int)HttpStatusCode.OK, true, "Cập nhật thành công");
        }

        private Task<IActionResult> BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}
