using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DesafioAeC.Infrastructure.Persistence
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        // Construtor que inicializa o contexto com base na string de conex�o do appsettings.json
        public MongoContext(IConfiguration configuration)
        {
            // L� a string de conex�o do arquivo appsettings.json
            var connectionString = configuration.GetConnectionString("MongoDb");

            // Inicializa o MongoClient com a string de conex�o
            var client = new MongoClient(connectionString);

            // Nome do banco de dados que voc� vai usar (substitua por seu nome de banco)
            _database = client.GetDatabase("myDatabase");
        }

        // Propriedade para acessar o banco de dados
        public IMongoDatabase Database => _database;
    }
}
