using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RzNovel.Common.Resp
{
    public class RestResp<T>
    {
        public string code { get; set; }
        public string message { get; set; }

        public T data { get; set; }

        public RestResp()
        {
            code = "200";
            message = "Success";
        }
        public RestResp(string _code, string _message)
        {
            code = _code;
            message = _message;
        }

        public RestResp(T _data)
        {
            code = "200";
            message = "Success";
            data = _data;
        }

        public RestResp(string _code, string _message, T _data)
        {
            code = _code;
            message = _message;
            data = _data;
        }

        public static RestResp<T> ok(T _data)
        {
            return new RestResp<T>(_data);
        }

        public static RestResp<T> error(T _data)
        {
            return new RestResp<T>("500", "Internal Error", _data);
        }
    }
}
