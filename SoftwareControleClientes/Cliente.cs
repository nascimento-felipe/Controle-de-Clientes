using System;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SoftwareControleClientes
{
    [BsonIgnoreExtraElements]
    public sealed class Cliente
    {
        private int codigo;
        private String nome;
        private int idade;
        private StringBuilder senha = new StringBuilder();
        private string data;

        public int Codigo { get => codigo; set => codigo = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Nome { get => nome; set => nome = value; }
        public StringBuilder Senha { get => senha; set => senha = value; }
        public string Data { get => data; set => data = value; }

        public void CadastrarCliente(int cod)
        {
            Console.Write("  Seja bem vindo!\n"
                            + "    Digite o seu nome: ");
            Nome = Console.ReadLine().Trim();

            Console.Write("    Digite sua idade: ");
            Idade = (int.Parse(Console.ReadLine()));

            Console.Write("    Digite uma senha bem segura: ");

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

            string diaMes;
            Console.Write("\n    Digite a data da venda (DD/MM): ");
            diaMes = Console.ReadLine();

            if (diaMes == null || diaMes == "")
                diaMes = $"{DateTime.Today.Day}/{DateTime.Today.Month}";

            Data = $"{diaMes}/{DateTime.Now.Year}";

            Console.Clear();

            Codigo = cod;
        }

    }
}
