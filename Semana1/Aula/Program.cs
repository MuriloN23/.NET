﻿using System;

class Program
{
    static void Main()
    {
        // Variável do tipo double com parte fracionária
        double numeroDouble = 10.75;

        // Convertendo double para int (parte fracionária será truncada)
        int numeroInteiro = (int)numeroDouble;

        // Exibindo os resultados
        Console.WriteLine($"Número Double: {numeroDouble}");
        Console.WriteLine($"Número Inteiro após conversão: {numeroInteiro}");
    }
}
