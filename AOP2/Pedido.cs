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

        }

        public Pedido(int pedidoId, float valorDoProduto, string descricaoDoProduto)
        {
            this.pedidoId = pedidoId;
            this.dataEmissao = DateTime.Now;
            this.valorDoProduto = valorDoProduto;
            this.descricaoDoProduto = descricaoDoProduto;
        }

        public int pedidoId { get; set; }   

        public DateTime dataEmissao { get; set; }

        public float valorDoProduto { get; set; }

        public string descricaoDoProduto { get; set; }

        public float calcularPrecoTotal()
        {
            return 0f;
        }

        public override string ToString()
        {
            return $"Id: {pedidoId}  Descricao: {descricaoDoProduto} Valor: {valorDoProduto} Data: {dataEmissao.ToString()}";

        }
    }
}
