using System;
using System.Collections.Generic;
using System.Text;
using IGym.IRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace IGym.EFRepository.Impl
{
    public class AddDbService : IAddDbService
    {
        public void AddService(string connection, IServiceCollection services)
        {
            services.AddDbContextPool<EfDbContext>(options => { options.UseMySQL(connection); });
            //services.AddSingleton<IDbContext, EfDbContext>();
        }
    }
}
