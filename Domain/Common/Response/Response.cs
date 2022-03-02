using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public class Response : IResponse
    {
        public Response(bool success,string message) 
            : this(success)
        {
            Message = message;
        }

        public Response(bool success)
        {
            Success = success;
        }

        public string Message { get; }
        public bool Success { get; }
    }
}
