using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DesafioAeC.Infrastructure.Scraping
{
    public class SeleniumScraper : IScraperService
    {
        private readonly IWebDriver _driver;

        // Construtor que inicializa o Selenium WebDriver
        public SeleniumScraper()
        {
            // Inicializa corretamente a variável _driver
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Roda sem interface gráfica
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            _driver = new ChromeDriver(options); // Atribui à variável de instância
        }

        // Método para realizar o scraping no site da Alura
        public async Task<List<Course>> ScrapeCoursesAsync(string searchTerm)
        {
            var courses = new List<Course>();

            // Verifica se o driver está inicializado corretamente antes de usá-lo
            if (_driver == null)
            {
                throw new System.Exception("Erro: ChromeDriver não foi inicializado corretamente.");
            }

            // Navega até o site da Alura
            _driver.Navigate().GoToUrl("https://www.alura.com.br/");

            // Localiza o campo de busca e insere o termo de pesquisa
            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();

            // Aguarda carregar os resultados
            await Task.Delay(2000);

            // Faz o scraping dos cursos exibidos
            var courseElements = _driver.FindElements(By.CssSelector(".curso"));

            foreach (var courseElement in courseElements)
            {
                var title = courseElement.FindElement(By.CssSelector(".titulo")).Text;
                var professor = courseElement.FindElement(By.CssSelector(".professor")).Text;
                var duration = courseElement.FindElement(By.CssSelector(".duracao")).Text;
                var description = courseElement.FindElement(By.CssSelector(".descricao")).Text;

                var course = new Course(title, professor, duration, description);
                courses.Add(course);
            }

            return courses;
        }

        // Método para liberar os recursos do WebDriver
        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
