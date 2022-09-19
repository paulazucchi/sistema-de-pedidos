using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Gerente : Funcionario
    {

        public string Senha { get; set; }

        public override float CalcularDesconto(float valorProduto)
        {

            return valorProduto * 0.8f;
        }

        public Gerente()
        {
            Senha = "123";
        }
    }
}
