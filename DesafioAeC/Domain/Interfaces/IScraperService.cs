using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;

namespace DesafioAeC.Domain.Interfaces
{
    public interface IScraperService
    {
        // Método para realizar a busca e obter os cursos a partir do termo de pesquisa
        Task<List<Course>> ScrapeCoursesAsync(string searchTerm);
    }
}
