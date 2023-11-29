using System;
using System.Collections.Generic;
using System.Linq;

namespace POGDevConsultorio
{
    public class Pessoa
    {
        private string cpf;

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF
        {
            get => cpf;
            private set
            {
                if (value.Length == 11)
                {
                    cpf = value;
                }
                else
                {
                    throw new ArgumentException("O CPF deve ter 11 dígitos.");
                }
            }
        }

        public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            this.cpf = string.Empty;
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public virtual void Apresentar()
        {
            Console.WriteLine($"Nome: {Nome}, Data de Nascimento: {DataNascimento.ToShortDateString()}, CPF: {CPF}");
        }
    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }

    public class Paciente : Pessoa
    {
        public Sexo Sexo { get; private set; }
        public string Sintomas { get; private set; }

        public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
            : base(nome, dataNascimento, cpf)
        {
            Sexo = sexo;
            Sintomas = sintomas;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Paciente - Sexo: {Sexo}, {base.Nome}, {base.DataNascimento.ToShortDateString()}, CPF: {base.CPF}, Sintomas: {Sintomas}");
        }
    }

    public class Medico : Pessoa
    {
        public string CRM { get; private set; }

        public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
            : base(nome, dataNascimento, cpf)
        {
            CRM = crm;
        }

        public override void Apresentar()
        {
            Console.WriteLine($"Médico - CRM: {CRM}, {base.Nome}, {base.DataNascimento.ToShortDateString()}, CPF: {base.CPF}");
        }
    }

    public class Consultorio
    {
        private HashSet<Medico> medicos;
        private HashSet<Paciente> pacientes;

        public Consultorio()
        {
            medicos = new HashSet<Medico>();
            pacientes = new HashSet<Paciente>();
        }

        public void AdicionarMedico(Medico medico)
        {
            if (!CRMJaExiste(medico.CRM))
            {
                medicos.Add(medico);
            }
            else
            {
                throw new ArgumentException($"Médico com CRM {medico.CRM} já cadastrado.");
            }
        }

        public void AdicionarPaciente(Paciente paciente)
        {
            if (!CPFJaExiste(paciente.CPF))
            {
                pacientes.Add(paciente);
            }
            else
            {
                throw new ArgumentException($"Paciente com CPF {paciente.CPF} já cadastrado.");
            }
        }

        public void GerarRelatorioPessoas()
        {
            Console.WriteLine("\nRelatório de Médicos:");
            foreach (var medico in medicos)
            {
                medico.Apresentar();
            }

            Console.WriteLine("\nRelatório de Pacientes:");
            foreach (var paciente in pacientes)
            {
                paciente.Apresentar();
            }
        }

        public void RelatorioMedicosIdade(int idadeMinima, int idadeMaxima)
        {
            var medicosFiltrados = medicos.Where(medico =>
                (DateTime.Now.Year - medico.DataNascimento.Year) >= idadeMinima &&
                (DateTime.Now.Year - medico.DataNascimento.Year) <= idadeMaxima);

            Console.WriteLine($"\nRelatório de Médicos com idade entre {idadeMinima} e {idadeMaxima} anos:");
            foreach (var medico in medicosFiltrados)
            {
                medico.Apresentar();
            }
        }

        public void RelatorioPacientesIdade(int idadeMinima, int idadeMaxima)
        {
            var pacientesFiltrados = pacientes.Where(paciente =>
                (DateTime.Now.Year - paciente.DataNascimento.Year) >= idadeMinima &&
                (DateTime.Now.Year - paciente.DataNascimento.Year) <= idadeMaxima);

            Console.WriteLine($"\nRelatório de Pacientes com idade entre {idadeMinima} e {idadeMaxima} anos:");
            foreach (var paciente in pacientesFiltrados)
            {
                paciente.Apresentar();
            }
        }

        public void RelatorioPacientesSexo(Sexo sexo)
        {
            var pacientesFiltrados = pacientes.Where(paciente => paciente.Sexo == sexo);

            Console.WriteLine($"\nRelatório de Pacientes do sexo {sexo}:");
            foreach (var paciente in pacientesFiltrados)
            {
                paciente.Apresentar();
            }
        }

        public void RelatorioPacientesOrdemAlfabetica()
        {
            var pacientesOrdenados = pacientes.OrderBy(paciente => paciente.Nome);

            Console.WriteLine("\nRelatório de Pacientes em ordem alfabética:");
            foreach (var paciente in pacientesOrdenados)
            {
                paciente.Apresentar();
            }
        }

        public void RelatorioPacientesPorSintomas(string textoSintomas)
        {
            var pacientesFiltrados = pacientes.Where(paciente => paciente.Sintomas.Contains(textoSintomas));

            Console.WriteLine($"\nRelatório de Pacientes com sintomas contendo '{textoSintomas}':");
            foreach (var paciente in pacientesFiltrados)
            {
                paciente.Apresentar();
            }
        }

        public void RelatorioAniversariantesDoMes(int mes)
        {
            var aniversariantes = medicos.Concat<Pessoa>(pacientes)
                .Where(p => p.DataNascimento.Month == mes)
                .OrderBy(p => p.DataNascimento.Day);

            Console.WriteLine($"\nRelatório de Aniversariantes do mês {mes}:");
            foreach (var pessoa in aniversariantes)
            {
                pessoa.Apresentar();
            }
        }

        private bool CRMJaExiste(string crm)
        {
            foreach (var medico in medicos)
            {
                if (medico.CRM == crm)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CPFJaExiste(string cpf)
        {
            foreach (var paciente in pacientes)
            {
                if (paciente.CPF == cpf)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Consultorio consultorio = new Consultorio();

                Medico medico1 = new Medico("Dr. Murilo", new DateTime(1992, 12, 3), "12345678901", "CRM12345");
                Medico medico2 = new Medico("Dr. Carlos", new DateTime(1995, 3, 11), "54398432109", "CRM65421");
                Medico medico3 = new Medico("Dra. Maria", new DateTime(1985, 11, 10), "98765432109", "CRM54321");
                Medico medico4 = new Medico("Dra. Carla", new DateTime(1991, 4, 7), "82514276598", "CRM73416");

                Paciente paciente1 = new Paciente("Goku", new DateTime(2001, 11, 1), "11223344556", Sexo.Masculino, "Enjoo");
                Paciente paciente2 = new Paciente("Naruto", new DateTime(1988, 9, 16), "99352466554", Sexo.Masculino, "Dor de barriga");
                Paciente paciente3 = new Paciente("João", new DateTime(2000, 2, 15), "62934254556", Sexo.Masculino, "Febre");
                Paciente paciente4 = new Paciente("Ana", new DateTime(1998, 7, 20), "99887766554", Sexo.Feminino, "Dor de cabeça");

                consultorio.AdicionarMedico(medico1);
                consultorio.AdicionarMedico(medico2);
                consultorio.AdicionarMedico(medico3);
                consultorio.AdicionarMedico(medico4);

                consultorio.AdicionarPaciente(paciente1);
                consultorio.AdicionarPaciente(paciente2);
                consultorio.AdicionarPaciente(paciente3);
                consultorio.AdicionarPaciente(paciente4);

                consultorio.RelatorioMedicosIdade(30, 50);
                consultorio.RelatorioPacientesIdade(18, 40);
                consultorio.RelatorioPacientesSexo(Sexo.Masculino);
                consultorio.RelatorioPacientesOrdemAlfabetica();
                consultorio.RelatorioPacientesPorSintomas("Dor");
                consultorio.RelatorioAniversariantesDoMes(12);

                consultorio.GerarRelatorioPessoas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
