using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Infrastructure.Persistence;
using MongoDB.Driver;

namespace DesafioAeC.Infrastructure.Repositories
{
    public class MongoRepository : IRepository
    {
        private readonly IMongoCollection<Course> _courses;

        // Injeção de dependência do contexto do MongoDB
        public MongoRepository(MongoContext context)
        {
            _courses = context.Database.GetCollection<Course>("Courses");
        }

        // Adiciona um curso no banco de dados MongoDB
        public async Task AddAsync(Course course)
        {
            await _courses.InsertOneAsync(course);
        }

        // Retorna todos os cursos armazenados no MongoDB
        public async Task<List<Course>> GetAllAsync()
        {
            return await _courses.Find(_ => true).ToListAsync();
        }
    }
}
