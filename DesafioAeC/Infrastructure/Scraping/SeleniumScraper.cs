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
            // Inicializa o ChromeDriver, certifique-se de que o caminho para o driver est� correto
            _driver = new ChromeDriver();
        }

        // M�todo para realizar o scraping no site da Alura
        public async Task<List<Course>> ScrapeCoursesAsync(string searchTerm)
        {
            // A lista de cursos que ser� retornada
            var courses = new List<Course>();

            // Navega at� o site da Alura
            _driver.Navigate().GoToUrl("https://www.alura.com.br/");

            // Localiza o campo de busca e insere o termo de pesquisa
            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();

            // Aguarda carregar os resultados (pode ajustar esse tempo de acordo com a performance)
            await Task.Delay(2000); // tempo de espera para carregar os resultados

            // Faz o scraping dos cursos exibidos (exemplo gen�rico, ajustar de acordo com o HTML do site)
            var courseElements = _driver.FindElements(By.CssSelector(".curso")); // ajuste o seletor conforme o HTML real

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

        // M�todo para liberar os recursos do WebDriver
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
