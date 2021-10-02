using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareControleClientes
{
    class Cliente
    {
        private String nome;
        private int idade;
        private int codigo;
        private StringBuilder senha = new StringBuilder();


        public void setIdade(int idade)
        {
            if (idade <= 0)
            {
                this.idade = 0;
                Console.WriteLine("Digite uma idade válida.");
            }
            else
            {
                this.idade = idade;
            }
        }
        public int getIdade() 
        {
            return idade; 
        }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public StringBuilder Senha { get => senha; set => senha = value; }

        public void CadastrarCliente(int cod)
        {
            Console.WriteLine("  Seja bem vindo!\n"
                + "    Digite o seu nome: ");
            nome = Console.ReadLine().Trim();
            Console.Clear();

            Console.WriteLine("    Digite sua idade:");
            setIdade(int.Parse(Console.ReadLine()));
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

                else if(key.Key != ConsoleKey.Backspace) senha.Append(key.KeyChar);
            }
            Console.Clear();

            codigo = cod;
        }
    }
}
