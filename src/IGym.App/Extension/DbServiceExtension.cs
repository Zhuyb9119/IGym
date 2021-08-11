using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGym.IRepository.Model;
using Microsoft.Extensions.DependencyInjection;

namespace IGym.WebApi.Extension
{
    public static class DbServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection serivce, OrmType ormType)
        {
            switch (ormType)
            {
                case OrmType.EntityFramework:

                    break;
                case OrmType.Dapper:
                    break;
                default:
                    break;
            }
            return serivce;
        }
    }
}
