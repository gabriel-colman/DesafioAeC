using Microsoft.Extensions.DependencyInjection;
using DesafioAeC.Application.Services;
using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Infrastructure.Repositories;
using DesafioAeC.Infrastructure.Scraping;
using DesafioAeC.Infrastructure.Persistence;

namespace DesafioAeC.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Adiciona o MongoContext como serviço Singleton
            services.AddSingleton<MongoContext>();

            // Adiciona a implementação do IRepository
            services.AddScoped<IRepository, MongoRepository>();

            // Adiciona o serviço de scraping
            services.AddScoped<IScraperService, SeleniumScraper>();

            // Adiciona o serviço de scraping de cursos
            services.AddScoped<CourseScraperService>();

            return services;
        }
    }
}
