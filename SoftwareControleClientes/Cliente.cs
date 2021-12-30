using System;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SoftwareControleClientes
{
    [BsonIgnoreExtraElements]
    public sealed class Cliente
    {
        private long id;
        private String nome;
        private int idade;
        private StringBuilder senha = new StringBuilder();
        private string data;

        public long Id { get => id; set => id = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Nome { get => nome; set => nome = value; }
        public StringBuilder Senha { get => senha; set => senha = value; }
        public string Data { get => data; set => data = value; }

        public void CadastrarCliente(long cod)
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

            Id = cod;
        }

    }
}
