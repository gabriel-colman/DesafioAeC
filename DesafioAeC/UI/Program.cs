using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DesafioAeC.Application.Services;
using DesafioAeC.Shared;

namespace DesafioAeC.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configuração do host para injeção de dependências
            var host = CreateHostBuilder(args).Build();

            // Obtém o serviço de scraping através da injeção de dependências
            var scraperService = host.Services.GetRequiredService<CourseScraperService>();

            Console.WriteLine("Digite o termo de busca para o scraping:");
            var searchTerm = Console.ReadLine();

            // Executa o scraping e salva os resultados
            await scraperService.ScrapeAndSaveAsync(searchTerm);

            Console.WriteLine("Scraping concluído e cursos salvos com sucesso!");

            // Exibe todos os cursos salvos no MongoDB
            var courses = await scraperService.GetAllCoursesAsync();
            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }
        }

        // Método para configurar o HostBuilder e carregar injeção de dependências
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Chama a classe de injeção de dependência para configurar os serviços
                    services.AddApplicationServices();
                });
    }
}
