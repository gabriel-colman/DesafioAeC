using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DesafioAeC.Infrastructure.Persistence
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        // Construtor que inicializa o contexto com base na string de conexão do appsettings.json
        public MongoContext(IConfiguration configuration)
        {
            // Lê a string de conexão do arquivo appsettings.json
            var connectionString = configuration.GetConnectionString("MongoDb");

            // Inicializa o MongoClient com a string de conexão
            var client = new MongoClient(connectionString);

            // Nome do banco de dados que você vai usar (substitua por seu nome de banco)
            _database = client.GetDatabase("myDatabase");
        }

        // Propriedade para acessar o banco de dados
        public IMongoDatabase Database => _database;
    }
}
