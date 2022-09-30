using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Classes
{
    public class Response<T>
    {
        public Header Header { get; set; }

        public T Data { get; set; }
    }
}
