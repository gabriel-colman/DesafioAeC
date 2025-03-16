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

            // Obtenção do serviço de scraping via injeção de dependências
            var scraperService = host.Services.GetRequiredService<CourseScraperService>();

            Console.WriteLine("Digite o termo de busca para o scraping:");
            var searchTerm = Console.ReadLine();

            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("O termo de busca não pode ser vazio.");
                return;
            }

            // Executa o scraping e salva os cursos no MongoDB
            await scraperService.ScrapeAndSaveAsync(searchTerm);
            Console.WriteLine("Scraping concluído e cursos salvos com sucesso!");

            // Exibe os cursos salvos
            var courses = await scraperService.GetAllCoursesAsync();
            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }
        }

        // Configuração do HostBuilder para injeção de dependências
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddApplicationServices(); // Chama o método de extensão que registra os serviços
                });
    }
}