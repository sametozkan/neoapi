using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Response
{
    public interface IDataResponse <out T> : IResponse
    {
        T List { get; }
    }
}
