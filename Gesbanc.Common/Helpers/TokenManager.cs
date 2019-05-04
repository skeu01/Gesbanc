using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gesbanc.Common.Helpers
{
    public class TokenManager
    {
        /// <summary>
        /// Generates a new token
        /// </summary>
        /// <param name="idUser">id User</param>
        /// <returns>token as string</returns>
        public string GenerateToken(int idUser, string secret)
        {

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, idUser.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //user.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }


    }
}
