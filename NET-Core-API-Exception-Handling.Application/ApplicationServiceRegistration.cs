using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NET_Core_API_Exception_Handling.Application.Services;
using NET_Core_API_Exception_Handling.Application.ValidationClasses;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<CreatePersonValidation>();
            services.AddScoped<UpdatePersonValidator>();



            return services;
        }

    }
}
