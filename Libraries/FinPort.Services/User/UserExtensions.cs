using FinPort.Core.DtoModels;
using FinPort.Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinPort.Services.User
{
    public partial class UserExtensions : BaseExtensions<Users, UsersDTO>
    {
        public string GetFullName(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return string.Empty;
        }

        public string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }

        public bool IsPasswordValid(string hashed, string input)
        {
            return BCrypt.Net.BCrypt.Verify(input, hashed);
        }

        public string LoginToken(GenerateTokenModel model, IOptions<JwtAuthentication> _jwtAuthentication)
        {
            var token = new JwtSecurityToken(
                    issuer: _jwtAuthentication.Value.ValidIssuer,
                    audience: _jwtAuthentication.Value.ValidAudience,
                    claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    },
                    expires: DateTime.UtcNow.AddDays(30),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: _jwtAuthentication.Value.SigningCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Users MapToEntity(UsersDTO entity2)
        {
            return new Users()
            {
                Username = entity2.Username,
                Email = entity2.Email,
                FirstName = entity2.FirstName,
                LastName = entity2.LastName,
                Password = entity2.Password,
                Wallet = new Wallets()
                {
                    Amount = entity2.Wallet != null ? entity2.Wallet.Amount : 0,
                    CurrencyId = entity2.Wallet != null && entity2.Wallet.Currency != null ? entity2.Wallet.Currency.CurrencyId : 0
                }
            };
        }

        public UsersDTO MapToModel(Users entity1)
        {
            return new UsersDTO()
            {
                UserId = entity1.UserId,
                Email = entity1.Email,
                FirstName = entity1.FirstName,
                LastName = entity1.LastName,
                Password = entity1.Password,
                Username = entity1.Username
            };
        }
    }
}
