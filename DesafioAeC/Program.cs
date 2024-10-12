using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DesafioAeC.Application.Services;
using DesafioAeC.Shared;

namespace DesafioAeC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Obten��o do servi�o de scraping via inje��o de depend�ncias
            var scraperService = host.Services.GetRequiredService<CourseScraperService>();

            Console.WriteLine("Digite o termo de busca para o scraping:");
            var searchTerm = Console.ReadLine();

            // Executa o scraping e salva os cursos no MongoDB
            await scraperService.ScrapeAndSaveAsync(searchTerm);
            Console.WriteLine("Scraping conclu�do e cursos salvos com sucesso!");

            // Exibe os cursos salvos
            var courses = await scraperService.GetAllCoursesAsync();
            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }
        }

        // Configura��o do HostBuilder para inje��o de depend�ncias
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddApplicationServices(); // Chama o m�todo de extens�o que registra os servi�os
                });
    }
}
