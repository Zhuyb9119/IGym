using System;
using System.Collections.Generic;
using System.Text;
using IGym.Interface.IRepository;

namespace IGym.IRepository.Interface
{
    public interface IDbContext
    {
        IDataRepository Context { get; }
    }
}
