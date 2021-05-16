using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMAspNet.Models;
using HRMAspNet.Interfaces;
using HRMAspNet.Common;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AministrativeareasController : ControllerBase
    {
        private readonly HRMContext _context;
        private readonly IAdministrativeArea _iAdministrativeArea;

        public AministrativeareasController(HRMContext context, IAdministrativeArea administrativeArea)
        {
            _context = context;
            _iAdministrativeArea = administrativeArea;
        }

        // GET: api/Aministrativeareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrativearea>>> GetAministrativearea()
        {
            return await _iAdministrativeArea.GetAministrativearea();
        }

        // GET: api/Aministrativeareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrativearea>> GetAministrativearea(Guid id)
        {
            return await _iAdministrativeArea.GetAministrativearea(id);
        }

        // PUT: api/Aministrativeareas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ActionServiceResult>> PutAministrativearea(Guid id, Administrativearea aministrativearea)
        {
            return await _iAdministrativeArea.PutAministrativearea(id, aministrativearea);
        }

        // POST: api/Aministrativeareas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Administrativearea>> PostAministrativearea(Administrativearea administrativearea)
        {
            _context.Aministrativearea.Add(administrativearea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAministrativearea", new { id = administrativearea.AdministrativeAreaId }, administrativearea);
        }

        // DELETE: api/Aministrativeareas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrativearea>> DeleteAministrativearea(Guid id)
        {
            var aministrativearea = await _context.Aministrativearea.FindAsync(id);
            if (aministrativearea == null)
            {
                return NotFound();
            }

            _context.Aministrativearea.Remove(aministrativearea);
            await _context.SaveChangesAsync();

            return aministrativearea;
        }   

       
    }
}
