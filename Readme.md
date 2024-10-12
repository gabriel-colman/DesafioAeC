# Desafio AeC Automação

## Descrição

Este projeto foi desenvolvido como parte do desafio de automação da AeC. A automação realiza buscas no site da **Alura** por um termo fornecido pelo usuário e captura os dados de cursos (título, professor, carga horária e descrição). Os dados capturados são armazenados no **MongoDB**.

O projeto foi desenvolvido utilizando **C#**, **Selenium WebDriver** para automação da busca no site, e **MongoDB** para persistência dos dados.

## Estrutura do Projeto

O projeto segue a arquitetura **Domain-Driven Design (DDD)**, organizado nas seguintes camadas:

### Estrutura de Pastas:

```
/DesafioAeC │ ├── /Domain │ ├── /Entities │ │ └── Course.cs │ ├── /Interfaces │ │ ├── IRepository.cs │ │ └── IScraperService.cs │ └── /ValueObjects │ └── SearchTerm.cs │ ├── /Application │ ├── /Services │ │ └── CourseScraperService.cs │ └── /DTOs │ └── CourseDTO.cs │ ├── /Infrastructure │ ├── /Repositories │ │ └── MongoRepository.cs │ ├── /Persistence │ │ └── MongoContext.cs │ └── /Scraping │ └── SeleniumScraper.cs │ ├── /UI │ └── Program.cs │ ├── /Tests │ ├── CourseScraperServiceTests.cs │ └── MongoRepositoryTests.cs │ ├── /Shared │ └── DependencyInjection.cs │ ├── appsettings.json ├── README.md └── DesafioAeC.sln
```


### Arquivos Principais:

- **Domain/Entities/Course.cs**: Define a entidade `Course`, representando um curso com título, professor, carga horária e descrição.
- **Application/Services/CourseScraperService.cs**: Serviço que coordena o scraping de dados e a persistência no banco de dados.
- **Infrastructure/Scraping/SeleniumScraper.cs**: Responsável por realizar a automação do navegador com Selenium para buscar os cursos no site da Alura.
- **Infrastructure/Persistence/MongoContext.cs**: Configura o acesso ao MongoDB utilizando a string de conexão fornecida no `appsettings.json`.
- **Program.cs**: Ponto de entrada da aplicação, solicita ao usuário o termo de busca e executa o scraping.

## Pré-requisitos

- **.NET 8.0 SDK**: Certifique-se de ter o .NET SDK 8.0 ou superior instalado em sua máquina.
- **MongoDB**: Instale e configure o MongoDB localmente ou crie uma conta no [MongoDB Atlas](https://www.mongodb.com/cloud/atlas).
- **ChromeDriver**: O Selenium WebDriver utiliza o ChromeDriver para automatizar o navegador Chrome. Ele será instalado automaticamente com o pacote `Selenium.WebDriver.ChromeDriver`.

## Configuração

### 1. Configurar o `appsettings.json`

Antes de executar o projeto, configure a string de conexão com o MongoDB em `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  
  "ConnectionStrings": {
    "MongoDb": "mongodb+srv://<username>:<password>@cluster0.mongodb.net/myDatabase?retryWrites=true&w=majority"
  }
}

```

## 2. Restaurar as Dependências
Restaurar todas as dependências do projeto utilizando o comando:

```
dotnet restore
```

Isso garantirá que todos os pacotes necessários, como Selenium, MongoDB.Driver, e Moq, sejam instalados.

Execução
1. Executar o Projeto
Para iniciar a aplicação, utilize o seguinte comando:

```
dotnet run --project DesafioAeC
```

## 2. Interação com o Usuário
Ao executar a aplicação, o programa solicitará que você insira um termo de busca. Após inserir o termo, o Selenium realizará o scraping no site da Alura e os cursos encontrados serão armazenados no MongoDB.

```
Digite o termo de busca para o scraping:
```
Depois que o scraping for concluído, a aplicação exibirá os cursos salvos no banco de dados.

## 3. Testes
O projeto inclui testes unitários escritos com xUnit. Para executar os testes, utilize o comando:

```
dotnet test
```
Isso executará os testes para garantir que o scraping e a persistência no MongoDB estão funcionando corretamente.

# Dependências
As principais bibliotecas utilizadas no projeto são:

MongoDB.Driver: Biblioteca para interação com o MongoDB.
Selenium.WebDriver: Biblioteca para automação de navegadores.
Selenium.WebDriver.ChromeDriver: Driver para automação do Chrome.
Moq: Biblioteca para criação de mocks em testes.
xUnit: Framework de testes unitários.

### Estrutura de Injeção de Dependência
A injeção de dependências foi configurada no arquivo DependencyInjection.cs. As seguintes dependências são registradas:

MongoContext: Configura o MongoDB.
MongoRepository: Implementa a interface IRepository para interagir com o MongoDB.
SeleniumScraper: Implementa a interface IScraperService para realizar o scraping com Selenium.
CourseScraperService: Coordena o fluxo de scraping e persistência de dados.
Considerações Finais
Este projeto demonstra como utilizar automação com Selenium para buscar dados em um site e salvá-los em um banco de dados MongoDB. Sinta-se à vontade para expandir o projeto com mais funcionalidades ou ajustar os seletores de HTML conforme necessário.

Se você tiver dúvidas ou encontrar problemas, entre em contato.
```
markdown
```

### Explicação do Conteúdo:

1. **Descrição do Projeto**: Explica o que o projeto faz e quais são os principais componentes.
2. **Estrutura de Pastas**: Detalha a estrutura do projeto, incluindo as camadas de domínio, aplicação, infraestrutura, e testes.
3. **Configuração do `appsettings.json`**: Mostra como configurar a string de conexão do MongoDB.
4. **Execução**: Explica como executar o projeto e interagir com o programa.
5. **Dependências**: Lista as bibliotecas principais que o projeto utiliza.
6. **Injeção de Dependências**: Descreve como o projeto está configurado para injeção de dependências.
7. **Testes**: Explica como rodar os testes unitários.

Este arquivo `README.md` serve como guia completo para qualquer desenvolvedor que queira entender, con