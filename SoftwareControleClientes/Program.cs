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
            Console.WriteLine($"ID: {c.Id}\n" +
                              $"Nome: {c.Nome}\n" +
                              $"Idade: {c.Idade}\n" +
                              $"Data: {c.Data}");
            Console.WriteLine("-----------------------------");
        }
        private static void AlterarUsuario()
        {
            Cliente cliente = new Cliente();

            Console.Write(" Digite a data do cliente: ");
            string data = Console.ReadLine();

            if (data == null || data == "")
                data = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";

            Console.Write(" Digite o código do cliente: ");
            int id = Int32.Parse(Console.ReadLine());

            var collection = ClienteDAO.GetInstance.GetClientesCollectionDAO();
            Console.Clear();

            Console.Write(" Digite o novo nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write(" Digite a nova idade: ");
            cliente.Idade = Int32.Parse(Console.ReadLine());

            Console.Write(" Digite a nova senha: ");
            cliente.Senha = GetInvisibleInputString();

            ClienteDAO.GetInstance.UpdateClienteDAO(collection, cliente, data, id);

            Console.Clear();
            Console.WriteLine(" Cliente atualizado!");
            WaitEnterBePressed();
        }
        private static void DeletarUsuario()
        {
            Console.Write(" Digite a data: ");
            string data = Console.ReadLine();

            if (data == null || data == "")
                data = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";

            Console.Write(" Digite o código: ");
            int codigo = Int32.Parse(Console.ReadLine());

            var collections = ClienteDAO.GetInstance.GetClientesCollectionDAO();
            ClienteDAO.GetInstance.DeleteClienteDAO(collections, codigo, data);

            Console.Clear();
            Console.Write(" Dados deletados! ");
            WaitEnterBePressed();
        }
        private static StringBuilder GetInvisibleInputString()
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
            int i = 0; // tirar esse 'i' daqui
            int opcao;

            do
            {
                Console.Clear();
                SendWelcomeMessage(DateTime.Now.Hour);

                // menu 1
                Console.Write("  Menu Principal\n"
                            + "    Escolha uma opção:\n"
                            + "      1. Cadastrar novo cliente\n"
                            + "      2. Listar clientes\n"
                            + "      3. Alterar Cliente\n"
                            + "      4. Deletar Cliente\n"
                            + "     -1. Sair.\n\n" 
                            + "    Opção escolhida: ");
                opcao = int.Parse(Console.ReadLine());
                try
                {

                    if (opcao != -1)
                    {
                        Console.Clear();

                        switch (opcao)
                        {
                            case 1: // Cadastrar cliente
                                Cliente novoCliente = new Cliente();
                                var clientesCollection = ClienteDAO.GetInstance.GetClientesCollectionDAO();

                                long lastClienteId = ClienteDAO.GetInstance.GetLastInsertedDocumentClientesDAO(clientesCollection).Id;

                                novoCliente.CadastrarCliente(++lastClienteId);

                                Console.WriteLine("Cadastrando cliente...");

                                
                                ClienteDAO.GetInstance.InsertClienteDAO(clientesCollection, novoCliente);


                                Console.WriteLine($"Cadastro de {novoCliente.Nome} concluído!");
                                i++;

                                WaitEnterBePressed();

                                break;
                            case 2: // Listar cliente(s)

                                Console.Write(" Menu de Listagem\n" +
                                              "  1. Listar todos os clientes\n" +
                                              "  2. Listar clientes por data\n\n" +
                                              " Opção escolhida: ");
                                int escolha = Int32.Parse(Console.ReadLine());

                                switch (escolha)
                                {
                                    case 1:
                                        List<Cliente> clientes = new List<Cliente>();
                                        var collection = ClienteDAO.GetInstance.GetClientesCollectionDAO();
                                        clientes = ClienteDAO.GetInstance.ListClientesDAO(collection);

                                        foreach (Cliente c in clientes)
                                        {
                                            WriteUserOnScreen(c);
                                        }

                                        WaitEnterBePressed();
                                        break;
                                    case 2:
                                        Console.Write(" Digite a data para procurar(DD/MM/AAAA): ");
                                        string data = Console.ReadLine();

                                        if (data == null || data == "")
                                            data = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";

                                        var colecao = ClienteDAO.GetInstance.GetClientesCollectionDAO();

                                        clientes = ClienteDAO.GetInstance.ListClientesByDataDAO(colecao, data);
                                        
                                        Console.Clear();

                                        foreach (Cliente c in clientes)
                                        {
                                            WriteUserOnScreen(c);
                                        }

                                        WaitEnterBePressed();
                                        break;
                                    default:
                                        break;
                                }
   
                                break;
                            case 3: // Alterar cliente

                                AlterarUsuario();

                                break;
                            case 4: // Deletar cliente

                                DeletarUsuario();

                                break;
                            default:
                                Console.WriteLine("Por favor, digite um valor válido!");
                                WaitEnterBePressed();
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n  *** Erro encontrado *** \n  Tipo: {e.GetType()}. \n  Mensagem: {e.Message}");
                    WaitEnterBePressed();
                }
            } while (opcao != -1);
            }
            
        }
    }
