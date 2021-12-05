using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infraestruture.Repository
{
    //CLASSE SEM ESTAR ABSTRAIDA


    public class AlunoRepository : IAlunoRepository
    {
        public void Create(Aluno aluno)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false)
              .Build();


            var mongoconnectionstring = config.GetSection("MONGO_CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase("Aluno");
            var collection = database.GetCollection<Aluno>("Aluno");


            collection.InsertOne(aluno);


        }

        public void Delete(string RA)
        {

            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false)
              .Build();


            var mongoconnectionstring = config.GetSection("MONGO_CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase("Aluno");
            var collection = database.GetCollection<Aluno>("Aluno");

            var filter = Builders<Aluno>.Filter.Eq("RA", RA);

            collection.DeleteOne(filter);
        }

        public Aluno Get(string RA)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            var mongoconnectionstring = config.GetSection("MONGO_CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase("Aluno");
            var collection = database.GetCollection<Aluno>("Aluno");


            //var filter = Builders<Aluno>.Filter.Eq(x => x.RA, RA);

            var filter = Builders<Aluno>.Filter.Eq("RA", RA);


            var retorno = collection.Find(filter).ToList().FirstOrDefault();
                       
            if ( retorno == null)
            {
                throw new NullReferenceException("Objeto é nulo");
            }


            return retorno;

        }

        public void Update(Aluno aluno, string RA)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false)
                 .Build();


            var mongoconnectionstring = config.GetSection("MONGO_CONECTION_STRING").Value;

            MongoClient dbClient = new MongoClient(mongoconnectionstring);

            var database = dbClient.GetDatabase("Aluno");
            var collection = database.GetCollection<Aluno>("Aluno");


            var filter = Builders<Aluno>.Filter.Eq("RA", RA);
            var filter2 = Builders<Aluno>.Update.Set("RA", aluno.RA).Set("CPF", aluno.CPF).Set("Nome", aluno.Nome);

            collection.UpdateOne(filter, filter2);


        }
    }
}
