using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal abstract class Funcionario
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }

        public abstract float CalcularDesconto( float valorProduto);

    }
}
