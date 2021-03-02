#region Referencias
using Domain.AlphaTIC.DAL.Repository.Implementation;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion Referencias

namespace Domain.AlphaTIC.Services
{   
    public class StartupBusinessLayer
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
