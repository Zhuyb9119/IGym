using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IGym.Application.Core;
using IGym.IRepository.Interface;
using IGym.IRepository.Model;
using Microsoft.Extensions.DependencyInjection;

namespace IGym.WebApi.Extension
{
    public static class DbServiceExtension
    {
        public static IServiceCollection AddDbService(this IServiceCollection serivce, string connection, OrmType ormType)
        {
            DependencyInject(serivce, connection, ormType);
            return serivce;
        }

        private static void DependencyInject(IServiceCollection serivce, string connection, OrmType ormType)
        {
            string dirPath = string.Empty;
            string match = string.Empty;
            switch (ormType)
            {
                case OrmType.EntityFramework:
                    match = "EFRepository";
                    break;
                case OrmType.Dapper:
                    break;
                default:
                    break;
            }

           

#if DEBUG
            dirPath = Path.Combine(Environment.CurrentDirectory, @"bin\Debug\netcoreapp3.1");
#else
            if (string.IsNullOrEmpty(dirPath)) return;
#endif

            var items = AssemblyLocator.AssemblyFinder(dirPath, match);
            foreach (var item in items)
            {
                string typeName = "";
                object context = Activator.CreateInstance(item, match);

                if (context == null) continue;

                if (context.GetType().IsAssignableFrom(typeof(IDbContext)))
                {
                    //依赖注入(未完成)
                    ((IDbContext)context).AddService(serivce, connection);
                }
            }
        }
    }
}
