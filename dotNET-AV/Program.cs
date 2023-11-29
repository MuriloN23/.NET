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
    class Program
    {
        static void Main()
        {
            try
            {
                Medico medico1 = new Medico("Dr. Murilo", new DateTime(1992, 3, 12), "12345678901", "CRM12345");
                Medico medico2 = new Medico("Dr. Carlos", new DateTime(1995, 3, 11), "54398432109", "CRM65421");
                Medico medico3 = new Medico("Dra. Maria", new DateTime(1985, 5, 10), "98765432109", "CRM54321");
                Medico medico4 = new Medico("Dra. Carla", new DateTime(1991, 4, 7), "82514276598", "CRM73416");

                Consultorio consultorio = new Consultorio();

                consultorio.AdicionarMedico(medico1);
                consultorio.AdicionarMedico(medico2);
                consultorio.AdicionarMedico(medico3);
                consultorio.AdicionarMedico(medico4);

                consultorio.GerarRelatorioMedicos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
