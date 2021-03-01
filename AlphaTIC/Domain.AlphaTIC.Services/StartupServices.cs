﻿#region Referencias
using Domain.AlphaTIC.BussinesLayer.Implementation;
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion Referencias

namespace Domain.AlphaTIC.Services
{
    public class StartupServices
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDocumentTypeBL, DocumentTypeBL>();
            StartupBusinessLayer.ConfigureServices(services, connectionString);
        }
    }
}