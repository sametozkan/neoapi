using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public DataResponse(T list, bool success, string message) 
            : base(success, message)
        {
            List = list;
        }

        public DataResponse(T list,bool success) 
            : base(success)
        {
            List = list;
        }

        public T List { get; }
    }
}
