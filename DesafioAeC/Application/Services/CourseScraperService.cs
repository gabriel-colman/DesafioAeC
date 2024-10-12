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

        // Inje��o de depend�ncia do reposit�rio e do scraper
        public CourseScraperService(IRepository repository, IScraperService scraperService)
        {
            _repository = repository;
            _scraperService = scraperService;
        }

        // M�todo respons�vel por realizar a busca e salvar os resultados no reposit�rio
        public async Task ScrapeAndSaveAsync(string searchTerm)
        {
            // Realiza o scraping utilizando o servi�o de scraping
            var courses = await _scraperService.ScrapeCoursesAsync(searchTerm);

            // Itera sobre os cursos capturados e os salva no reposit�rio
            foreach (var course in courses)
            {
                await _repository.AddAsync(course);
            }
        }

        // M�todo para obter todos os cursos salvos no reposit�rio
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
