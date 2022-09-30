using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Classes
{
    public static class ResponseExtension
    {
        public static Response<T> AsResponse<T>(this T result, int code, string messageText = "")
        {
            Response<T> response = new Response<T>();
            Header header = new Header()
            {
                Code = code,
                Message = messageText
            };

            if (code >= 200 && code < 300)
                header.Success = true;
            else
                header.Success = false;

            response.Header = header;
            response.Data = result;

            return response;
        }
    }
}
