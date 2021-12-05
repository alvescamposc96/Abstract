using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Interface
{
    //CLASSE QUE CARREGA OS MÉTODOS DO BANCO DE DADOS SEM DEFINIÇÕES, CLASSE ABSTRATA


    public interface IAlunoRepository
    {
        public void Create(Aluno aluno );

        public Aluno Get(string RA );

        public void Update(Aluno aluno, string RA);

        public void Delete(string RA);




    }
}
