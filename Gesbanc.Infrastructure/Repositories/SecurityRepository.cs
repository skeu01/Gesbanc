using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gesbanc.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<UserEntity>, ISecurityRepository
    {
        protected new readonly GesbancContext _dbContext;

        public SecurityRepository(GesbancContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// User Authentication
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>user entity</returns>
        public async Task<UserEntity> AuthenticateAsync(string username, string password)
        {

            var user = await _dbContext.Set<UserEntity>()
                .SingleOrDefaultAsync(x => x.Username == username && x.Password == password && x.Active == true);

            // check if user exists
            if (user == null)
                return null;

            // authentication successful
            return user;
        }
    }
}
