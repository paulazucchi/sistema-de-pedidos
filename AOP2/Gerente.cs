using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Gerente : Funcionario
    {
        private string Senha { get; set; }

        public override float calcularDesconto(float valorProduto)
        {

            return valorProduto * 0.8f;
        }

        

        
    }
}
