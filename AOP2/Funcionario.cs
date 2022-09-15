using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal abstract class Funcionario
    {
        private string Nome { get; set; }
        private int Matricula { get; set; }

        public abstract float calcularDesconto( float valorProduto);

    }
}
