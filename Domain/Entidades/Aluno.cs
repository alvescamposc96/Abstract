using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entidades
{
    public class Aluno 
    {
        [BsonElement]   //ESSA ANOTAÇÃO É PARA MAPEAR COM O BANCO
        public string Nome { get; set; }

        [BsonElement]
        public string CPF { get; set; }

        [BsonElement]
        [BsonId]
        public string RA { get; set; }



    }
}
