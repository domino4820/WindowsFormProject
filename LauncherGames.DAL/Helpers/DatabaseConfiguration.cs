using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LauncherGames.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LauncherGames.DAL.Models;

namespace LauncherGames.DAL.Helpers
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LauncherGamesContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
