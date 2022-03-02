using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public class ErrorResponse : Response
    {
        public ErrorResponse() : base(false)
        {
        }

        public ErrorResponse(string message) : base(false, message)
        {
        }
    }
}
