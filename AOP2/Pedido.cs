using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Pedido
    {

        public Pedido()
        {
            this.ListaProdutos = new List<Produto>();
            this.DataEmissao = DateTime.Now;
        }

        public Pedido(int pedidoId, float valorDoProduto, string descricaoDoProduto)
        {
            this.PedidoId = pedidoId;
            this.DataEmissao = DateTime.Now;
            this.ValorFinal = 0; ;
            this.ListaProdutos = new List<Produto>();
        }

        public int PedidoId { get; set; }   

        public DateTime DataEmissao { get; set; }

        public float ValorFinal { get; set; }


        public List<Produto> ListaProdutos { get; set; }






        public float CalcularPrecoTotal()
        {
            float total = 0;

            foreach (Produto produto in ListaProdutos)
            {
                total += produto.ValorTotal();
            }

            return total;
        }

        public override string ToString()
        {
            return $"Pedido Id: {PedidoId}   \nValor Total: {CalcularPrecoTotal()} \nValor Final: {ValorFinal} \nData: {DataEmissao.ToString()}";

        }

        public void AdicionarProduto(String descricao, float valor, int quantidade)
        {
            Produto produto = new Produto(descricao, valor, quantidade);

            this.ListaProdutos.Add(produto);

            this.ValorFinal = CalcularPrecoTotal();
        }

        public void ExibirProdutos()
        {
            for (int i = 0; i < ListaProdutos.Count; i++)
            {
                Produto produto = ListaProdutos[i];
                Console.WriteLine($"Produto: {i} Descricao: {ListaProdutos[i].Descricao} | Valor Unitario: {ListaProdutos[i].Valor} | Quantidade: {ListaProdutos[i].Quantidade}");
            }
                
        }

        public void ExibirPedido()
        {
            
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(ToString());
            ExibirProdutos();
            Console.WriteLine("---------------------------------------------");
        }

    }
}
