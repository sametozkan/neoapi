using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        public SuccessDataResponse(T list, string message) : base(list, true, message)
        {

        }

        public SuccessDataResponse(T list) : base(list, true)
        {

        }

        public SuccessDataResponse(string message) : base(default, true,message)
        {

        }

        public SuccessDataResponse() : base(default, true)
        {

        }
    }
}
