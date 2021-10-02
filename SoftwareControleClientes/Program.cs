using System;

namespace SoftwareControleClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = DateTime.Now.Hour;
            String[] clientes;
            int opcao;

            Cliente novoCliente = new Cliente();

            // Controle da mensagem de boas vindas.
            SendWelcomeMessage(hour);

            do
            {
                Console.WriteLine("  Escolha uma opção:\n"
                    + "    1. Cadastrar novo cliente\n"
                    + "    2. Ver todos os clientes\n"
                    + "    3. Deletar Clienten\n"
                    + "    4. Alterar Cliente\n"
                    + "   -1. Sair.");

                opcao = int.Parse(Console.ReadLine());
                if (opcao != -1)
                {

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
