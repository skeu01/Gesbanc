using Gesbanc.Infrastructure.Context;
using Gesbanc.Infrastructure.Contracts;
using Gesbanc.Model.Entities;

namespace Gesbanc.Infrastructure.Repositories
{
    public class EntidadRepository : BaseRepository<EntidadEntity>, IEntidadRepository
    {
        protected new readonly GesbancContext _dbContext;

        public EntidadRepository(GesbancContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
