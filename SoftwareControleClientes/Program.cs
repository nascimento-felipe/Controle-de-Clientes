using System;

namespace SoftwareControleClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = DateTime.Now.Hour;
            string[] clientes = new string[10];
            int i = 0;
            int opcao;

            // Controle da mensagem de boas vindas.
            SendWelcomeMessage(hour);

            do
            {
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

                            clientes.SetValue($"{novoCliente.Nome}, {novoCliente.Senha}, {novoCliente.getIdade()}", i);

                            Console.WriteLine($"Cadastro concluído. Bem vindo(a), {novoCliente.Nome}!\n\n\n(senha: {novoCliente.Senha})");
                            break;
                        case 2:
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

        static void SendWelcomeMessage(int hour)
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

    }

}
