using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Service;
using Project.Domain.Services;
using Projeto.Infra.Persistence.Repositories;
using Projeto.Infra.Transactions;

namespace Project.IoC
{
    public class DependencyInjectionResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IServicePerson, ServicePerson>();
            services.AddScoped<IRepositoryPerson, RepositoryPerson>();

            services.AddScoped<IServicePersonPhone, ServicePersonPhone>();
            services.AddScoped<IRepositoryPersonPhone, RepositoryPersonPhone>();

            services.AddScoped<IServicePhoneNumberType, ServicePhoneNumberType>();
            services.AddScoped<IRepositoryPhoneNumberType, RepositoryPhoneNumberType>();
        }
    }
}
