using Application.Helpers;
using Application.Helpers.Jwt;
using Domain.Common.Response;
using Domain.Constants;
using Domain.Entities.Concrete;
using Domain.Enums;
using MediatR;
using Persistence.Abstract;

namespace Application.Handlers.Users.Commands
{
    public class RegisterUserCommand : IRequest<IDataResponse<BearerToken>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IDataResponse<BearerToken>>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            public RegisterUserCommandHandler(IUserRepository userRepository,ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<IDataResponse<BearerToken>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

                User user = new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    BirthDay = request.BirthDay,
                    RoleId = (byte)UserRoles.User,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                _userRepository.Add(user);
                await _userRepository.SaveChangesAsync();
                var accesToken = _tokenHelper.CreateToken<BearerToken>(user);
                return new SuccessDataResponse<BearerToken>(accesToken, UserResponseMessages.RegistrationSuccessful);
            }
        }
    }
}
