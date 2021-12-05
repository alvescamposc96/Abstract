using System;
using Domain.Entidades;
using Infraestruture.Repository;

namespace ProjetoSQLeMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var aluno = new Aluno()
            {
                Nome= "Cristiane",
                CPF = "367.224.278-34",
                RA = "12345678"

            };


            var alunoRepository = new AlunoRepository();

           alunoRepository.Create(aluno);

            // alunoRepository.Delete("6789");

            //  alunoRepository.Update(aluno, "6789333332");

           //var alunoex =  alunoRepository.Get("000000000");

           // Console.WriteLine($"Aluno: {alunoex.Nome} com CPF: {alunoex.CPF} e com RA: { alunoex.RA}");

        }
    }
}
