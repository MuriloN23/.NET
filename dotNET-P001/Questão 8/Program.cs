using System;

class Program
{
    static void Main()
    {
        // Variáveis
        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        // Verificar as condições
        bool condicao1 = num1 > num2;
        bool condicao2 = num3 == (num1 + num2);

        // Verificar se ambas as condições são verdadeiras
        if (condicao1 && condicao2)
        {
            Console.WriteLine("num1 é maior que num2 e num3 é igual a num1 + num2.");
        }
        else
        {
            Console.WriteLine("As condições não são atendidas simultaneamente.");
        }
    }
}
