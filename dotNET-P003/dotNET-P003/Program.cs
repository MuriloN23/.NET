using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Tupla representando um produto
    private static List<(int codigo, string nome, int quantidade, double precoUnitario)> estoque = new List<(int, string, int, double)>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ConsultarProduto();
                    break;
                case "3":
                    AtualizarEstoque();
                    break;
                case "4":
                    GerarRelatorios();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.WriteLine("Informe o código do produto:");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o nome do produto:");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe a quantidade em estoque:");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o preço unitário:");
            double precoUnitario = double.Parse(Console.ReadLine());

            // Adiciona o produto à lista
            estoque.Add((codigo, nome, quantidade, precoUnitario));

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante o cadastro: {ex.Message}");
        }
    }

    static void ConsultarProduto()
    {
        try
        {
            Console.WriteLine("Informe o código do produto:");
            int codigo = int.Parse(Console.ReadLine());

            // Busca o produto na lista
            var produto = estoque.FirstOrDefault(p => p.codigo == codigo);

            if (produto.Equals(default((int, string, int, double))))
            {
                throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
            }

            // Exibe as informações do produto
            Console.WriteLine($"Código: {produto.codigo}");
            Console.WriteLine($"Nome: {produto.nome}");
            Console.WriteLine($"Quantidade em Estoque: {produto.quantidade}");
            Console.WriteLine($"Preço Unitário: {produto.precoUnitario:C2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a consulta: {ex.Message}");
        }
    }

    static void AtualizarEstoque()
    {
        try
        {
            Console.WriteLine("Informe o código do produto:");
            int codigo = int.Parse(Console.ReadLine());

            // Busca o produto na lista
            var produto = estoque.FirstOrDefault(p => p.codigo == codigo);

            if (produto.Equals(default((int, string, int, double))))
            {
                throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
            }

            Console.WriteLine("Informe a quantidade a ser adicionada (positiva) ou removida (negativa):");
            int quantidadeAtualizacao = int.Parse(Console.ReadLine());

            // Atualiza a quantidade em estoque
            produto.quantidade += quantidadeAtualizacao;

            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a atualização do estoque: {ex.Message}");
        }
    }

    static void GerarRelatorios()
    {
        try
        {
            Console.WriteLine("Informe o limite de quantidade para o relatório 1:");
            int limiteQuantidade = int.Parse(Console.ReadLine());

            // Relatório 1: Lista de produtos com quantidade em estoque abaixo do limite informado pelo usuário
            var relatorio1 = estoque.Where(p => p.quantidade < limiteQuantidade);
            Console.WriteLine("Relatório 1: Produtos com quantidade em estoque abaixo do limite");
            ExibirRelatorio(relatorio1);

            Console.WriteLine("Informe o valor mínimo para o relatório 2:");
            double valorMinimo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor máximo para o relatório 2:");
            double valorMaximo = double.Parse(Console.ReadLine());

            // Relatório 2: Lista de produtos com valor entre um mínimo e um máximo informados pelo usuário
            var relatorio2 = estoque.Where(p => p.precoUnitario >= valorMinimo && p.precoUnitario <= valorMaximo);
            Console.WriteLine("Relatório 2: Produtos com valor entre o mínimo e o máximo");
            ExibirRelatorio(relatorio2);

            // Relatório 3: Valor total do estoque e valor total de cada produto de acordo com seu estoque
            var valorTotalEstoque = estoque.Sum(p => p.quantidade * p.precoUnitario);
            Console.WriteLine($"Relatório 3: Valor total do estoque: {valorTotalEstoque:C2}");
            Console.WriteLine("Detalhes do estoque:");
            ExibirRelatorio(estoque);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a geração de relatórios: {ex.Message}");
        }
    }

    static void ExibirRelatorio(IEnumerable<(int codigo, string nome, int quantidade, double precoUnitario)> relatorio)
    {
        foreach (var produto in relatorio)
        {
            Console.WriteLine($"Código: {produto.codigo}");
            Console.WriteLine($"Nome: {produto.nome}");
            Console.WriteLine($"Quantidade em Estoque: {produto.quantidade}");
            Console.WriteLine($"Preço Unitário: {produto.precoUnitario:C2}");
            Console.WriteLine();
        }
    }
}

// Exceção personalizada para indicar que o produto não foi encontrado
class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string mensagem) : base(mensagem)
    {
    }
}
