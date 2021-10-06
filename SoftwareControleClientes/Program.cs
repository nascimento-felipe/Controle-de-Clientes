using System;
using System.Collections.Generic;

namespace SoftwareControleClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = DateTime.Now.Hour;
            List<Cliente> clientes = new List<Cliente>();
            int i = 0;
            int opcao;

            // Controle da mensagem de boas vindas.

            do
            {
                Console.Clear();

                SendWelcomeMessage(hour);

                Console.WriteLine("  Escolha uma opção:\n"
                    + "    1. Cadastrar novo cliente\n"
                    + "    2. Ver todos os clientes\n"
                    + "    3. Deletar Cliente\n"
                    + "    4. Alterar Cliente\n"
                    + "   -1. Sair.");

                opcao = int.Parse(Console.ReadLine());
                if (opcao != -1)
                {
                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            Cliente novoCliente = new Cliente();
                            novoCliente.CadastrarCliente(i);

                            clientes.Add(novoCliente);

                            Console.WriteLine($"Cadastro de {clientes[i].Nome} concluído!");
                            i++;

                            WaitEnterBePressed();

                            break;
                        case 2:

                            Console.WriteLine($"Listando todos os clientes no sistema: (quantidade total = {clientes.Count})");

                            foreach (Cliente c in clientes)
                            {
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine($"\nID: {c.Codigo}" +
                                    $"\nNome: {c.Nome}" +
                                    $"\nIdade: {c.getIdade()}");
                                Console.WriteLine("-----------------------------");
                            }

                            WaitEnterBePressed();

                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
            } while (opcao != -1);
        }

        private static void SendWelcomeMessage(int hour)
        {
            if (hour >= 4 && hour <= 12)
            {
                Console.WriteLine("  Bom Dia!");
            }
            else if (hour >= 12 && hour <= 18)
            {
                Console.WriteLine("  Boa Tarde!");
            }
            else
            {
                Console.WriteLine("  Boa Noite!");
            }
        }

        private static void WaitEnterBePressed()
        {
            Console.WriteLine("\nAperte enter para continuar...");

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;
            }
        }

    }

}
