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
        public Task<ActionResult<IEnumerable<Aministrativearea>>> GetAministrativearea();
        public Task<ActionResult<Aministrativearea>> GetAministrativearea(Guid id);
        public Task<ActionResult<ActionServiceResult>> PutAministrativearea(Guid id, Aministrativearea aministrativearea);
        public Task<ActionResult<Aministrativearea>> PostAministrativearea(Aministrativearea aministrativearea);
        public Task<ActionResult<Aministrativearea>> DeleteAministrativearea(Guid id);


    }
}
