using CleanCommander.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CleanCommanderDbContext dbContext;

        public GenericRepository(CleanCommanderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetPagedReponse(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
