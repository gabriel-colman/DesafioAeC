using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using DesafioAeC.Application.Services;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Interfaces;

namespace DesafioAeC.Tests
{
    public class CourseScraperServiceTests
    {
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<IScraperService> _scraperServiceMock;
        private readonly CourseScraperService _courseScraperService;

        public CourseScraperServiceTests()
        {
            // Mock do repositório e do scraper
            _repositoryMock = new Mock<IRepository>();
            _scraperServiceMock = new Mock<IScraperService>();

            // Instancia o serviço a ser testado
            _courseScraperService = new CourseScraperService(_repositoryMock.Object, _scraperServiceMock.Object);
        }

        [Fact]
        public async Task ScrapeAndSaveAsync_ShouldSaveCourses()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course("Curso 1", "Professor 1", "10h", "Descrição 1"),
                new Course("Curso 2", "Professor 2", "20h", "Descrição 2")
            };

            // Configura o mock do serviço de scraping para retornar cursos
            _scraperServiceMock.Setup(s => s.ScrapeCoursesAsync(It.IsAny<string>())).ReturnsAsync(courses);

            // Act
            await _courseScraperService.ScrapeAndSaveAsync("RPA");

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Course>()), Times.Exactly(courses.Count));
        }

        [Fact]
        public async Task GetAllCoursesAsync_ShouldReturnAllCourses()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course("Curso 1", "Professor 1", "10h", "Descrição 1")
            };

            // Configura o mock do repositório para retornar uma lista de cursos
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(courses);

            // Act
            var result = await _courseScraperService.GetAllCoursesAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("Curso 1", result[0].Title);
        }
    }
}
