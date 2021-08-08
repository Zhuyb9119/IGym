using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.Interface.IRepository
{
    public interface IDataRepository : IDisposable
    {
        T Update<T>(T entity) where T : class;
        T Insert<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
