
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NET_Core_API_Exception_Handling.Application.Repo_Interfaces;
using NET_Core_API_Exception_Handling.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer
                    (configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncBaseRepository<>),typeof(BaseRepository<>));

            return services;
        }
    }
}
