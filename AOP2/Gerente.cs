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

        public float calcularDescontoMaior(float valorProduto)
        {
            return 0f;
        }
    }
}
