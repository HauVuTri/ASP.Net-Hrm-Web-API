using HRMAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Common
{
    public class CommonFunction
    {
        public static bool AministrativeareaExists(Guid id, HRMContext context)
        {
            return context.Aministrativearea.Any(e => e.AdministrativeAreaId == id);
        }
    }
}
