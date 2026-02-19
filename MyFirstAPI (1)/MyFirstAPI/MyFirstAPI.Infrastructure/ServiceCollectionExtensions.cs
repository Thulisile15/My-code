using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyFirstAPI.Infrastructure;

namespace MyFirstAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddDbContext<MyFirstAPIDBContext>();
            return collection;
        }
    }
}
