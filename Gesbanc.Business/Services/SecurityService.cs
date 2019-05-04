using Gesbanc.Business.Contracts;
using Gesbanc.Common.Helpers;
using Gesbanc.Infrastructure.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Gesbanc.Business.Services
{
    public class SecurityService : ISecurityService
    {
        private ISecurityRepository _repository;
        private TokenManager _tokenManager;
        private readonly AppSettings _appSettings;

        public SecurityService(ISecurityRepository repository, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _tokenManager = new TokenManager();
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns><c>jwt token</c>if authenticated, </returns>
        public async Task<string> AuthenticateAsync(string username, string password, string secret)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var userEntity = await _repository.AuthenticateAsync(username, password);

            if (userEntity == null)
                return null;

            var token = _tokenManager.GenerateToken(userEntity.Id, secret);
            return token;
        }
    }
}
