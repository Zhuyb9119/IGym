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
        public static IServiceCollection AddService(this IServiceCollection serivce, OrmType ormType)
        {
            DependencyInject(serivce, ormType);
            return serivce;
        }

        private static void DependencyInject(IServiceCollection serivce, OrmType ormType)
        {
            string dirPath = string.Empty;
            switch (ormType)
            {
                case OrmType.EntityFramework:
                    dirPath = "IGym.EFRepository";
                    break;
                case OrmType.Dapper:
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(dirPath)) return;

            var items = AssemblyLocator.AssemblyFinder(dirPath);
            foreach (var item in items)
            {
                string typeName = Path.GetFileNameWithoutExtension(item);
                object context = Activator.CreateInstance(item, typeName);

                if (context == null) continue;

                if (context.GetType().IsAssignableFrom(typeof(IDbContext)))
                {
                    //依赖注入(未完成)
                    ((IDbContext)context).AddService();
                }
            }
        }
    }
}
