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
        private String senha;


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
        public void setCodigo(int id)
        { 
            codigo = id; 
        }
        public int getCodigo()
        {
            return codigo;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
