using System;
using System.Collections.Generic;
using System.Text;
using IGym.Interface.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace IGym.IRepository.Interface
{
    public interface IDbContext
    {
        IDataRepository Context { get; }
        void AddService(IServiceCollection services, string connection);
    }
}
