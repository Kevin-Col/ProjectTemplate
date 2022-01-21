using Model.Emun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.OutputDto
{
    public class ApiResponse
    {
        public ApiCode Code { get; set; }
        public string Msg { get; set; }

    }
    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse()
        {

        }

        public ApiResponse(ApiCode code, string msg, T data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
        public T Data { get; set; }
    }
}
