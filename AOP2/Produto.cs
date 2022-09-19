using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Produto
    {

        public string Descricao { get; set; }
        public float Valor { get; set; }

        public int Quantidade { get; set; }

        

        public Produto(string descricao, float valor, int quantidade)
        {
            Descricao = descricao;
            Valor = valor;
            Quantidade = quantidade;
        }

        public float ValorTotal()
        {
            return Valor * Quantidade;
        }


    }
}
