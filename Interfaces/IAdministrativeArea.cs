using HRMAspNet.Common;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface IAdministrativeArea
    {
        public Task<ActionResult<IEnumerable<Administrativearea>>> GetAministrativearea();
        public Task<ActionResult<Administrativearea>> GetAministrativearea(Guid id);
        public Task<ActionResult<ActionServiceResult>> PutAministrativearea(Guid id, Administrativearea aministrativearea);
        public Task<ActionResult<Administrativearea>> PostAministrativearea(Administrativearea aministrativearea);
        public Task<ActionResult<Administrativearea>> DeleteAministrativearea(Guid id);


    }
}
