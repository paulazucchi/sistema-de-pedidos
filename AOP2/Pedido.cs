using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Pedido
    {
        private int pedidoId { get; set; }   

        private DateTime dataEmissao { get; set; }

        public float valorDoProduto { get; set; }

        public string descriçãoDoProduto { get; set; }

        public float calcularPrecoTotal()
        {
            return 0f;
        }
    }
}
