using System;
using System.Collections.Generic;
using System.Text;
using SoftwareControleClientes.MongoDAO;

namespace SoftwareControleClientes
{
    class Program
    {
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

        private static void WriteUserOnScreen(Cliente c)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"ID: {c.Codigo}" +
                              $"\nNome: {c.Nome}" +
                              $"\nIdade: {c.Idade}");
            Console.WriteLine("-----------------------------");
        }

        private static StringBuilder GetInvisibleInput()
        {
            StringBuilder senha = new StringBuilder();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha.Remove(senha.Length - 1, 1);
                }

                else if (key.Key != ConsoleKey.Backspace) senha.Append(key.KeyChar);
            }

            return senha;
        }

        static void Main(string[] args)
        {
            // criar método de criação de menus
            int hour = DateTime.Now.Hour;
            List<Cliente> clientes = new List<Cliente>();
            int i = 0;
            int opcao;

            try
            {
                do
                {
                    Console.Clear();

                    SendWelcomeMessage(hour);

                    // menu 1
                    Console.WriteLine("  Menu Principal\n"
                                    + "    Escolha uma opção:\n"
                                    + "      1. Cadastrar novo cliente\n"
                                    + "      2. Listar clientes\n"
                                    + "      3. Alterar Cliente\n"
                                    + "      4. Deletar Cliente\n"
                                    + "     -1. Sair.");

                    opcao = int.Parse(Console.ReadLine());

                    if (opcao != -1)
                    {
                        Console.Clear();

                        switch (opcao)
                        {
                            // Cadastrar cliente
                            case 1:
                                Cliente novoCliente = new Cliente();
                                novoCliente.CadastrarCliente();

                                var clientesCollection = ClienteDAO.GetInstance.GetClientesCollectionDAO();
                                ClienteDAO.GetInstance.InsertClienteDAO(clientesCollection, novoCliente);

                                clientes.Add(novoCliente);

                                Console.WriteLine($"Cadastro de {clientes[i].Nome} concluído!");
                                i++;

                                WaitEnterBePressed();

                                break;
                            // Listar cliente(s)
                            case 2:

                                var collection = ClienteDAO.GetInstance.GetClientesCollectionDAO();
                                clientes = ClienteDAO.GetInstance.ListClientesDAO(collection);

                                foreach (Cliente c in clientes)
                                {
                                    Console.WriteLine(c.Nome);
                                }

                                WaitEnterBePressed();

                                break;
                            // Alterar cliente
                            case 3:

                                break;
                            // Deletar cliente
                            case 4:

                                break;
                            default:

                                Console.WriteLine("Por favor, digite um valor válido!");
                                WaitEnterBePressed();

                                break;
                        }
                    }
                } while (opcao != -1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n  *** Erro encontrado *** \n  Tipo: {e.GetType()}. \n  Mensagem: {e.Message}");
            }
        }
    }

}
