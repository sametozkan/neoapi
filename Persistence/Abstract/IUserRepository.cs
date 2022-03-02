using Domain.Entities.Concrete;
using Persistence.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstract
{
    public interface IUserRepository : IEntityRepositoryBase<User>
    {
       
    }
}
