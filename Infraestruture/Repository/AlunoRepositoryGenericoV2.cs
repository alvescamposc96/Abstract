
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
    //CLASSE COMPLETAMENTE ABSTRAÍDA, METODOS GUARDADOS NO CONTRUTOR E CONTRUTOR ABSTRAIDO EM OUTRA CLASSE, NA CLASSE ABSTRACOESALUNOREPOSITORY

      public class AlunoRepositoryGenericoV2 : AbstracoesAlunoRepository<Aluno> , ClasseDoAluno<Aluno, string>
    {

        //private readonly IMongoCollection<Aluno> _collection;
        

            

            public void Create(Aluno  aluno)
            {
            
                _collection.InsertOne(aluno);

            }

            public void Delete(string RA)
            {
                var filter = Builders<Aluno>.Filter.Eq("RA", RA);

                _collection.DeleteOne(filter);
            }

            public Aluno Get(string RA)
            {

                //var filter = Builders<Aluno>.Filter.Eq(x => x.RA, RA);

                var filter = Builders<Aluno>.Filter.Eq("RA", RA);


                var retorno = _collection.Find(filter).ToList().FirstOrDefault();

                if (retorno == null)
                {
                    throw new NullReferenceException("Objeto é nulo");
                }


                return retorno;

            }

            public void Update(Aluno  aluno, string RA)
            {

                var filter = Builders<Aluno>.Filter.Eq("RA", RA);
                var filter2 = Builders<Aluno>.Update.Set("RA", aluno.RA).Set("CPF", aluno.CPF).Set("Nome", aluno.Nome);

                _collection.UpdateOne(filter, filter2);


            }
        }
    }




