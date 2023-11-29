using System;
using System.Collections.Generic;

namespace POGDevConsultorio
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            if (cpf.Length == 11)
            {
                CPF = cpf;
            }
            else
            {
                throw new ArgumentException("O CPF deve ter 11 dígitos.");
            }
        }
    }
}