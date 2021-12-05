using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infraestruture.Repository

    //CLASSE QUE ABSTRAI O CONSTRUTOR QUE CARREGA OS MÉTODOS DO BANCO  DE DADOS
{
    public abstract class AbstracoesAlunoRepository<T> 
    {

        public  readonly IMongoCollection<T> _collection;


        //Define o construtor do aluno em uma classe separada abstrata. Está sendo usada em AlunoRepositoryGenericoV2

        public AbstracoesAlunoRepository()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            var mongoconnectionstring = config.GetSection("MONGO_CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase(typeof(T).ToString());
            var collection = database.GetCollection<T>(typeof(T).ToString());

            _collection = collection;
        }

    }
}
