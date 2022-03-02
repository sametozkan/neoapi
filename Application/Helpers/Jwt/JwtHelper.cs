using Application.Extensions;
using Domain.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Helpers.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly JwtOptions _jwtOptions;
        private DateTime _expiration;
        public IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtOptions = _configuration.GetSection("JwtOptions").Get<JwtOptions>();
        }
        public BearerToken CreateToken<BearerToken>(User user) where BearerToken : IAccessToken, new()
        {
            _expiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_jwtOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_jwtOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new BearerToken()
            {
                Token = token,
                Expiration = _expiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(
           JwtOptions tokenOptions,
           User user,
           SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: _expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id);
            if (!string.IsNullOrEmpty(user.Name))
            {
                claims.AddName($"{user.Name}");
            }

            claims.Add(new Claim(ClaimTypes.Role, "User"));
            return claims;
        }
    }
}
