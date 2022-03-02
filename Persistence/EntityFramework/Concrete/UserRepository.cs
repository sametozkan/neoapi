using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstract;
using Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Concrete
{
    public class UserRepository : EntityRepositoryBase<User, MicrosoftDbContext>, IUserRepository
    {
        public UserRepository(MicrosoftDbContext context) : base(context)
        {
        }
    }
}
