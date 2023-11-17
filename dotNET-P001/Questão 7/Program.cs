using System;

class Program
{
    static void Main()
    {
        // Variáveis booleanas
        bool condicao1 = true;
        bool condicao2 = false;

        // Verificar se ambas as condições são verdadeiras
        bool ambasAsCondicoesSaoVerdadeiras = condicao1 && condicao2;

        // Exibir o resultado
        if (ambasAsCondicoesSaoVerdadeiras)
        {
            Console.WriteLine("Ambas as condições são verdadeiras.");
        }
        else
        {
            Console.WriteLine("Pelo menos uma das condições não é verdadeira.");
        }
    }
}
