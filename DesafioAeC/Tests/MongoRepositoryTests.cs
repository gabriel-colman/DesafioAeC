using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Moq;
using Xunit;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Infrastructure.Repositories;
using DesafioAeC.Infrastructure.Persistence;

namespace DesafioAeC.Tests
{
    public class MongoRepositoryTests
    {
        private readonly Mock<IMongoCollection<Course>> _mongoCollectionMock;
        private readonly Mock<MongoContext> _mongoContextMock;
        private readonly MongoRepository _mongoRepository;

        public MongoRepositoryTests()
        {
            _mongoCollectionMock = new Mock<IMongoCollection<Course>>();
            _mongoContextMock = new Mock<MongoContext>();
            _mongoContextMock.Setup(c => c.Database.GetCollection<Course>(It.IsAny<string>(), null)).Returns(_mongoCollectionMock.Object);

            _mongoRepository = new MongoRepository(_mongoContextMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldInsertCourse()
        {
            // Arrange
            var course = new Course("Curso 1", "Professor 1", "10h", "Descrição 1");

            // Act
            await _mongoRepository.AddAsync(course);

            // Assert
            _mongoCollectionMock.Verify(c => c.InsertOneAsync(course, null, default), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCourses()
        {
            // Arrange
            var courses = new List<Course>
                {
                    new Course("Curso 1", "Professor 1", "10h", "Descrição 1")
                };

            var cursorMock = new Mock<IAsyncCursor<Course>>();
            cursorMock.Setup(_ => _.Current).Returns(courses);
            cursorMock.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mongoCollectionMock.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Course>>(), null, default, default)).ReturnsAsync(cursorMock.Object);

            // Act
            var result = await _mongoRepository.GetAllAsync();

            // Assert
            Assert.Single(result);
        }
    }
}
