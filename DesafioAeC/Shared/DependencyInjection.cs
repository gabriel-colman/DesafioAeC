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
            // Adiciona o MongoContext como servi�o Singleton
            services.AddSingleton<MongoContext>();

            // Adiciona a implementa��o do IRepository
            services.AddScoped<IRepository, MongoRepository>();

            // Adiciona o servi�o de scraping
            services.AddScoped<IScraperService, SeleniumScraper>();

            // Adiciona o servi�o de scraping de cursos
            services.AddScoped<CourseScraperService>();

            return services;
        }
    }
}
