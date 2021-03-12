﻿using DottyLogs.Server.Hubs;
using DottyLogs.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DottyLogs
{
    public static class ServerExtensions
    {
        public static IServiceCollection AddDottyBackend(this IServiceCollection services)
        {
            services.AddGrpc();
            services.AddSignalR();

            return services;
        }

        public static IApplicationBuilder UseDottyBackend(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DottyLogsUpdateService>();
                endpoints.MapHub<UiUpdateHub>("/ui-updates");
            });

            return app;
        }
    }
}
