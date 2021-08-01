using Data;
using Infra.Clients;
using Infra.Factory;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infra
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAzureRepository, AzureRepository>();
            services.AddTransient<IDropboxRepository, DropboxRepository>();
            services.AddTransient<ICloudProviderFactory, CloudProviderFactory>();
            services.AddSingleton<ICloudProviderService, AzureService>();
            services.AddSingleton<ICloudProviderService, DropboxService>();
        }
    }
}
