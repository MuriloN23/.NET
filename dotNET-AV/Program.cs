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

    public class Medico : Pessoa
    {
        public string CRM { get; set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
            : base(nome, dataNascimento, cpf)
        {
            CRM = crm;
        }
    }

    public class Consultorio
    {

        private List<Medico> medicos;

        public Consultorio()
        {
            medicos = new List<Medico>();
        }

        public void AdicionarMedico(Medico medico)
        {
            medicos.Add(medico);
        }

        public void GerarRelatorioMedicos()
        {
            Console.WriteLine("Relatório de Médicos:");

            foreach (var medico in medicos)
            {
                Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}");
            }
        }
    }

}