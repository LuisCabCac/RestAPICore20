using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestAPICore20.Models;
using RestAPICore20.Models.Implements;
using RestAPICore20.Models.Interfaces;
using RestAPICore20.NoSQL.LiteDB.Repository;

namespace RestAPICore20.Infrastructure
{
    public static class IocConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {

            services.AddTransient<IStatable, StateImplements>();
            services.AddTransient<INoSQLRepository<StateModel>, LiteRepository<StateModel>>();
        }

    }
}
