using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {

        public ErrorDataResponse(T list,string message) : base(list, false,message)
        {

        }

        public ErrorDataResponse(T list) : base(list, false)
        {

        }

        public ErrorDataResponse(string message) : base(default, false,message)
        {

        }

        public ErrorDataResponse() : base(default, false)
        {

        }

    }
}
