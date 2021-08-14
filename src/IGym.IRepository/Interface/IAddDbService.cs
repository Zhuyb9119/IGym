using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace IGym.IRepository.Interface
{
    public interface IAddDbService
    {
        void AddService(IServiceCollection services, string connection);
    }
}
