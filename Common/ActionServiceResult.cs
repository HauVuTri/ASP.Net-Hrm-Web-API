using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Common
{
    public class ActionServiceResult<T>
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ActionServiceResult()
        {

        }
        public ActionServiceResult(int code, bool success, string message, T data)
        {
            Code = code;
            Success = success;
            Message = message;
            Data = data;
        }
    }
    public class ActionServiceResult
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ActionServiceResult(int code, bool success, string message, object data)
        {
            Code = code;
            Success = success;
            Message = message;
            Data = data;
        }

        public ActionServiceResult()
        {
        }
    }
}
