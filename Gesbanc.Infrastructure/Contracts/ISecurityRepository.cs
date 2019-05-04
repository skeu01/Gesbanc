using Gesbanc.Model.Entities;
using System.Threading.Tasks;

namespace Gesbanc.Infrastructure.Contracts
{
    public interface ISecurityRepository : IBaseRepository<UserEntity>
    {
        /// <summary>
        /// User Authentication
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>user entity</returns>
        Task<UserEntity> AuthenticateAsync(string username, string password);
    }
}