using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;

namespace DesafioAeC.Domain.Interfaces
{
    public interface IRepository
    {
        // M�todo para adicionar um curso ao reposit�rio de dados
        Task AddAsync(Course course);

        // M�todo para buscar todos os cursos armazenados no reposit�rio
        Task<List<Course>> GetAllAsync();
    }
}
