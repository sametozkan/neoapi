using Application.Dtos;
using AutoMapper;
using Domain.Common.Response;
using Domain.Constants;
using Domain.Entities.Concrete;
using MediatR;
using Persistence.Abstract;

namespace Application.Handlers.Users.Queries
{
    public class GetUsersQuery : IRequest<IDataResponse<IEnumerable<UserDto>>>
    {

        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IDataResponse<IEnumerable<UserDto>>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            public GetUsersQueryHandler(IUserRepository userRepository,IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var result = await _userRepository.GetListAsync();
                var users = result.Select(_mapper.Map<User, UserDto>);
                return new SuccessDataResponse<IEnumerable<UserDto>>(users,UserResponseMessages.UsersListed);
            }
        }
    }
}
