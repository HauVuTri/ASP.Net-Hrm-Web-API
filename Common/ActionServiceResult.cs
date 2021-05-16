using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Common
{
    public class ActionServiceResult
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ActionServiceResult()
        {

        }

        public ActionServiceResult(int code, bool success, string message)
        {
            Code = code;
            Success = success;
            Message = message;
        }
    }
}
