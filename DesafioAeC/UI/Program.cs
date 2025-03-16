// using System;
// using System.Threading.Tasks;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using DesafioAeC.Application.Services;
// using DesafioAeC.Shared;

// namespace DesafioAeC.UI
// {
//     class Program
//     {
//         static async Task Main(string[] args)
//         {
//             // Configura��o do host para inje��o de depend�ncias
//             var host = CreateHostBuilder(args).Build();

//             // Obt�m o servi�o de scraping atrav�s da inje��o de depend�ncias
//             var scraperService = host.Services.GetRequiredService<CourseScraperService>();

//             Console.WriteLine("Digite o termo de busca para o scraping:");
//             var searchTerm = Console.ReadLine();

//             // Executa o scraping e salva os resultados
//             await scraperService.ScrapeAndSaveAsync(searchTerm);

//             Console.WriteLine("Scraping conclu�do e cursos salvos com sucesso!");

//             // Exibe todos os cursos salvos no MongoDB
//             var courses = await scraperService.GetAllCoursesAsync();
//             foreach (var course in courses)
//             {
//                 Console.WriteLine(course.ToString());
//             }
//         }

//         // M�todo para configurar o HostBuilder e carregar inje��o de depend�ncias
//         public static IHostBuilder CreateHostBuilder(string[] args) =>
//             Host.CreateDefaultBuilder(args)
//                 .ConfigureAppConfiguration((context, config) =>
//                 {
//                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//                 })
//                 .ConfigureServices((context, services) =>
//                 {
//                     // Chama a classe de inje��o de depend�ncia para configurar os servi�os
//                     services.AddApplicationServices();
//                 });
//     }
// }
