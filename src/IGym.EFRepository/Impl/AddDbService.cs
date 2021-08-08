using System;
using System.Collections.Generic;
using System.Text;
using IGym.IRepository.Interface;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace IGym.EFRepository.Impl
{
    public class AddDbService : IAddDbService
    {
        public void AddService(IServiceCollection services)
        {
            services.AddEntityFrameworkMySQL();
        }
    }
}
