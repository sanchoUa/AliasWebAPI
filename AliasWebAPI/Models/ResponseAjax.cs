using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.Models
{
    public class ResponseAjax
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMsg { get; set; }

        public ResponseAjax()
        {
            IsSuccess = true;
        }

        public ResponseAjax(object data)
        {
            IsSuccess = true;
            Data = data;
        }

        public ResponseAjax(object data, string errorMsg)
        {
            IsSuccess = true;
            Data = data;
            ErrorMsg = errorMsg;
        }
    }
}
