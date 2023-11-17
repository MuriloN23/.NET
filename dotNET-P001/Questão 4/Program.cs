using System;

class Program
{
    static void Main()
    {
        // Variáveis
        int x = 10;
        int y = 3;

        // Adição
        int soma = x + y;
        Console.WriteLine($"Adição: {soma}");

        // Subtração
        int subtracao = x - y;
        Console.WriteLine($"Subtração: {subtracao}");

        // Multiplicação
        int multiplicacao = x * y;
        Console.WriteLine($"Multiplicação: {multiplicacao}");

        // Divisão (observe que é uma divisão de inteiros, o resultado será um inteiro)
        int divisao = x / y;
        Console.WriteLine($"Divisão: {divisao}");

        // Caso queira a parte decimal da divisão, você pode usar as conversões de ponto flutuante melhoradas
        double resultadoDivisaoDecimal = x / y;
        Console.WriteLine($"Divisão com parte decimal (usando conversões de ponto flutuante melhoradas): {resultadoDivisaoDecimal}");
    }
}
