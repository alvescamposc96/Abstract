using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Interface
{
    //CLASSE QUE CARREGA OS MÉTODOS DO BANCO DE DADOS SEM DEFINIÇÕES, CLASSE ABSTRATA

   public interface ClasseDoAluno<T,V> 
    {
        public void Create(T t);

        public Aluno Get(V v);

        public void Update(T t, V v);

        public void Delete(V v);



    }
}
