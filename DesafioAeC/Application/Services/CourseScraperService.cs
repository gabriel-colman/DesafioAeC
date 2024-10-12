using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Interfaces;

namespace DesafioAeC.Application.Services
{
    public class CourseScraperService
    {
        private readonly IRepository _repository;
        private readonly IScraperService _scraperService;

        // Injeção de dependência do repositório e do scraper
        public CourseScraperService(IRepository repository, IScraperService scraperService)
        {
            _repository = repository;
            _scraperService = scraperService;
        }

        // Método responsável por realizar a busca e salvar os resultados no repositório
        public async Task ScrapeAndSaveAsync(string searchTerm)
        {
            // Realiza o scraping utilizando o serviço de scraping
            var courses = await _scraperService.ScrapeCoursesAsync(searchTerm);

            // Itera sobre os cursos capturados e os salva no repositório
            foreach (var course in courses)
            {
                await _repository.AddAsync(course);
            }
        }

        // Método para obter todos os cursos salvos no repositório
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
