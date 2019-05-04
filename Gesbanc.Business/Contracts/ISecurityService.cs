using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gesbanc.Business.Contracts
{
    public interface ISecurityService
    {
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns><c>jwt token</c>if authenticated, </returns>
        Task<string> AuthenticateAsync(string username, string password, string secret);
    }
}
