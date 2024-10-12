using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;

namespace DesafioAeC.Domain.Interfaces
{
    public interface IRepository
    {
        // Método para adicionar um curso ao repositório de dados
        Task AddAsync(Course course);

        // Método para buscar todos os cursos armazenados no repositório
        Task<List<Course>> GetAllAsync();
    }
}
