using System;
using System.Collections.Generic;
using System.Text;
using IGym.Interface.IRepository;

namespace IGym.EFRepository.Impl
{
    public class EFDataRepository : IDataRepository
    {
        private readonly EfDbContext _context;
        public EFDataRepository(EfDbContext context)
        {
            this._context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
