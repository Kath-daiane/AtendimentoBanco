using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Fila para os clientes
        Queue<string> fila = new Queue<string>();

        // Passo 1: Adicionar 5 clientes à fila
        for (int i = 1; i <= 5; i++)
        {
            Console.Write("Digite o nome do cliente " + i + ": ");
            string nomeCliente = Console.ReadLine();

            Console.Write("O cliente " + nomeCliente + " é preferencial? (s/n): ");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "s")
            {
                // Se for preferencial, coloca no início
                fila = AdicionarPreferencialNoInicio(fila, nomeCliente);
            }
            else
            {
                fila.Enqueue(nomeCliente);
            }
        }

        // Passo 2: Atender os clientes
        Console.WriteLine("\nAtendendo clientes...");
        while (fila.Count > 0)
        {
            string cliente = fila.Dequeue();
            Console.WriteLine("Atendendo: " + cliente);
        }

        // Passo 3: Fila vazia
        Console.WriteLine("\nTodos os clientes foram atendidos.");
    }

    // Função para mover um cliente preferencial para o início da fila
    static Queue<string> AdicionarPreferencialNoInicio(Queue<string> fila, string cliente)
    {
        Queue<string> filaTemp = new Queue<string>();
        filaTemp.Enqueue(cliente);

        // Adiciona o restante dos clientes na fila temporária
        foreach (var c in fila)
        {
            filaTemp.Enqueue(c);
        }

        return filaTemp;
    }
}
