using System;
using System.Collections.Generic;
using System.Text;

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

            try
            {
                do
                {
                    Console.Clear();

                    SendWelcomeMessage(hour);

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
                                novoCliente.CadastrarCliente(i);

                                clientes.Add(novoCliente);

                                Console.WriteLine($"Cadastro de {clientes[i].Nome} concluído!");
                                i++;

                                WaitEnterBePressed();

                                break;
                            // Listar cliente(s)
                            case 2:

                                int opcaoListagem = 0;

                                Console.WriteLine("  Listagem de Clientes\n" +
                                                  "    Escolha uma opção:\n" +
                                                  "      1. Selecionar cliente por ID\n" +
                                                  "      2. Listar todos os clientes");

                                opcaoListagem = Int32.Parse(Console.ReadLine());

                                Console.Clear();

                                switch (opcaoListagem)
                                {
                                    // Selecionar cliente por ID
                                    case 1:

                                        Console.Write("Digite o valor do ID: ");

                                        int codigo = Int32.Parse(Console.ReadLine());
                                        Cliente userSelected = new Cliente();

                                        userSelected.Codigo = -1;

                                        userSelected = SearchForClientByID(clientes, codigo);

                                        Console.Clear();

                                        if (userSelected.Codigo == -1)
                                        {
                                            Console.WriteLine("Não há nenhum usuário com esse ID.");
                                            WaitEnterBePressed();
                                        } 
                                        else
                                        {
                                            WriteUserOnScreen(userSelected);
                                            WaitEnterBePressed();
                                        }


                                        break;
                                    // Selecionar todos os clientes no sistema
                                    case 2:

                                        Console.WriteLine($"Listando todos os clientes no sistema: (quantidade total = {clientes.Count})");

                                        foreach (Cliente c in clientes)
                                        {
                                            WriteUserOnScreen(c);
                                        }

                                        WaitEnterBePressed();

                                        break;
                                    default:

                                        Console.WriteLine("Por favor, digite um valor válido!");
                                        WaitEnterBePressed();

                                        break;
                                }

                                break;
                            // Alterar cliente
                            case 3:
                                break;
                            // Deletar cliente
                            case 4:

                                Console.Write("Digite o ID que deseja deletar: ");
                                int id = Int32.Parse(Console.ReadLine());

                                Cliente selectedUser = SearchForClientByID(clientes, id);

                                Console.Write("Digite a senha do usuário para deletar: ");
                                StringBuilder senha = GetInvisibleInput();

                                Console.Clear();

                                // debug pra deletar
                                Console.WriteLine($"Senha do usuário: \"{selectedUser.Senha}\"\nSenha digitada: \"{senha}\"\n\n");

                                if (selectedUser.Senha != senha)
                                {
                                    Console.WriteLine("Senha incorreta!");
                                    WaitEnterBePressed();
                                }
                                else
                                {
                                    clientes.RemoveAt(selectedUser.Codigo);
                                    Console.WriteLine("Usuário deletado com sucesso!");
                                    WaitEnterBePressed();
                                }


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
                              $"\nIdade: {c.getIdade()}");
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

        private static Cliente SearchForClientByID(List<Cliente> clientes, int codigo)
        {
            Cliente userSelected = new Cliente();

            foreach (Cliente c in clientes)
            {
                if (c.Codigo == codigo)
                {
                    userSelected = c;
                }
            }

            return userSelected;
        }

    }

}
