using Domain.Common.Response;
using Domain.Entities.Concrete;
using MediatR;
using Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Queries
{
    public class GetUsersQuery : IRequest<IDataResponse<IEnumerable<User>>>
    {

        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IDataResponse<IEnumerable<User>>>
        {
            private readonly IUserRepository _userRepository;
            public GetUsersQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IDataResponse<IEnumerable<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResponse<IEnumerable<User>>(await _userRepository.GetAllAsync());
            }
        }
    }
}
