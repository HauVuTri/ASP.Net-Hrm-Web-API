using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Entities
{
    public class RollCallResponse
    {
        public RollCallResponse()
        {
        }

        public Guid RollCallId { get; set; }
        public DateTime TimeCheckin { get; set; }

        public RollCallResponse(Guid rollCallId, DateTime timeCheckin)
        {
            RollCallId = rollCallId;
            TimeCheckin = timeCheckin;
        }
    }
}
