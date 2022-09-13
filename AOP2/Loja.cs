using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Loja
    {
        private List<Pedido> listaPedidos;
        private Funcionario f = new Funcionario(); 


        static void Main(string[] args)
        {
            Loja loja = new Loja();
            loja.inserirPedido();
        }

        public void Menu()
        {

        }

        public void inserirPedido()
        {
            Pedido p = new Pedido();
            p.descriçãoDoProduto = "Caneta";

            listaPedidos.Add(p);
        }

        public void buscarPedido()
        {

        }

        public void removerPedido()
        {

        }


    }
}
