using FgOnlinePortal.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FgOnlinePortal.Core.Utilities.Extensions.Connection
{
    public static  class ConnectionExtension
    {

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service ,IConfiguration configuration)
        {
            service.AddDbContext<FgOnlinePortalDbContext>(options =>
            {
                var connectionString = "ConnectionStrings:FgOnlinePortalConnection:Development";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }

    }
}
