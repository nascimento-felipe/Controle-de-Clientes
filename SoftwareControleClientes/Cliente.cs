using System;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SoftwareControleClientes
{
    [BsonIgnoreExtraElements]
    public sealed class Cliente
    {
        private ObjectId codigo;
        private String nome;
        private int idade;
        private StringBuilder senha = new StringBuilder();

        public Cliente()
        {
            this.codigo = ObjectId.GenerateNewId();
        }

        public ObjectId Codigo { get => codigo; set => codigo = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Nome { get => nome; set => nome = value; }
        public StringBuilder Senha { get => senha; set => senha = value; }

        public void CadastrarCliente()
        {
            Console.WriteLine("  Seja bem vindo!\n"
                + "    Digite o seu nome: ");
            nome = Console.ReadLine().Trim();
            Console.Clear();

            Console.WriteLine("    Digite sua idade:");
            Idade = (int.Parse(Console.ReadLine()));
            Console.Clear();

            Console.WriteLine("    Digite uma senha bem segura: ");

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

            Console.Clear();
        }

        public void AlterarCliente()
        {
            Console.Write("Digite o novo nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite a nova idade: ");
            Idade = Int32.Parse(Console.ReadLine());
        }
    }
}
