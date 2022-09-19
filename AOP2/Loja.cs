using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    internal class Loja
    {
        private List<Pedido> listaPedidos;
        private Gerente gerente;
        private Funcionario estagiario;
        private int idManager;


        public Loja()
        {
            listaPedidos = new List<Pedido>();
            idManager = 0;
            CadastrarFuncionarios();
        }



        static void Main(string[] args)
        {
            Loja loja = new Loja();

            int opcao = 0;
            do
            {
                loja.Menu();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        loja.InserirPedido();
                        break;
                    case 2:
                        loja.BuscarPedido();
                        break;
                    case 3:
                        loja.RemoverPedido();
                        break;
                    case 4:
                        loja.ExibirPedidos();
                        break;
                    case 5:
                        loja.AplicarDesconto();
                        break;
                    case 0:
                        Console.WriteLine("Até mais...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }


            } while (opcao != 0);


            _ = Console.ReadKey();
        }

        public void Menu()
        {
            Console.WriteLine("\nSelecione uma das opções:");
            Console.WriteLine("1 - Inserir Pedido");
            Console.WriteLine("2 - Buscar Pedido");
            Console.WriteLine("3 - Remover Pedido");
            Console.WriteLine("4 - Exibir Pedido");
            Console.WriteLine("5 - Aplicar Desconto");
            Console.WriteLine("0 - Sair\n");
        }

        public void InserirPedido()
        {
            
            Pedido pedido = MontarPedido();
            
            listaPedidos.Add(pedido);
            Console.WriteLine("Pedido Inserido com sucesso.");
        }

        public void BuscarPedido()
        {
            Console.Write("\nInforme o id do pedido: ");
            int buscarId = int.Parse(Console.ReadLine());

            
                
            var filtro = from p in listaPedidos 
                         where p.PedidoId == buscarId select p;


                //foreach (var p in filtro)
                //{
                //    if(p.pedidoId == buscarId)
                //    {
                //        Console.WriteLine(p.ToString());
                //    }
                //}


            if (filtro.Any())
            {

                foreach (var filtroItem in filtro)
                {
                    Console.WriteLine(filtroItem.ToString());
                }
            }
            else
            {
                Console.WriteLine("Id inválido!");
            }


        }

        public void RemoverPedido()
        {
            Console.Write("\nInforme o id do pedido: ");
            int buscarId = int.Parse(Console.ReadLine());

            bool pedidoNaoEncontrado = true;

            foreach (var pedido in listaPedidos)
            {
                if (pedido.PedidoId == buscarId)
                {
                    listaPedidos.Remove(pedido);
                    Console.WriteLine($"Foi realizada a remoção do pedido: {pedido.ToString()}");
                    pedidoNaoEncontrado = false;
                    break;
                }
            }

            if (pedidoNaoEncontrado)
            {
                Console.WriteLine("\nID informado invalido.");
            }


        }

        public void ExibirPedidos()
        {
            foreach(Pedido pedido in listaPedidos)
            {
                pedido.ExibirPedido();
            }
        }


        private Pedido MontarPedido()
        {
            idManager++;
            Pedido pedido = new Pedido();
            pedido.PedidoId = idManager;


            Console.WriteLine("\nEstamos montando seu pedido.");
            int opcaoPedido = -1;
            do
            {
                Console.WriteLine("\nSelecione uma das opções:");
                Console.WriteLine("1 - Adicionar Novo Produto");
                Console.WriteLine("2 - Finalizar Pedido\n");
                opcaoPedido = int.Parse(Console.ReadLine());

                switch (opcaoPedido)
                {
                    case 1:

                        Console.WriteLine("\nInforme a descrição do produto: ");
                        string descricao = Console.ReadLine();

                        //Console.WriteLine("Informe o valor do produto: ");
                        //float valor = Console.ReadLine();
                        float valor = this.EntrarValorProduto();
                        
                        //Console.WriteLine("Informe a quantidade do produto: ");
                        //int quantidade = int.Parse(Console.ReadLine());
                        int quantidade = this.EntrarQuantidadeProduto();

                        pedido.AdicionarProduto(descricao, valor, quantidade);
                        break;
                    case 2:
                        Console.WriteLine("\nSeu pedido foi concluido!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }



            } while (opcaoPedido!=2);


            return pedido;
        }

        private float EntrarValorProduto()
        {
            Console.WriteLine("\nInforme o valor unitário do produto: ");
            float valor;
            try
            {
                 valor = float.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("O valor entrado não é válido, tente novamente.");
                valor = EntrarValorProduto();
            }
            


            return valor;
        }

        private int EntrarQuantidadeProduto()
        {
            Console.WriteLine("\nInforme a quantidade do produto: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("A quantidade informada não é válida, tente novamente.");
                return EntrarQuantidadeProduto();
            }
        }

        public void CadastrarFuncionarios()
        {
            gerente = new Gerente();
            gerente.Nome = "Hugo";
            gerente.Matricula = 2022456;
            gerente.Senha = "123";


            estagiario = new Estagiario();
            estagiario.Nome = "Ana";
            estagiario.Matricula = 2022132;

        }

        public void AplicarDesconto()
        {

            Console.WriteLine("Informe a senha do gerente: ");
            string senha= Console.ReadLine();
            Funcionario funcionario;

            if (gerente.Senha.Equals(senha))
            {
                Console.WriteLine("\nVocê logou como gerente.");
                funcionario = gerente;
            }
            else
            {
                Console.WriteLine("\nVocê logou como estagiário.");
                funcionario = estagiario;
            }



            Console.WriteLine("Informe o id do pedido que deseja aplicar o desconto: ");
            int idPedido = int.Parse(Console.ReadLine());

            bool pedidoNaoEncontrado = true;

            foreach (var pedido in listaPedidos)
            {
                if (pedido.PedidoId == idPedido)
                {
                    float valorDescontado = funcionario.CalcularDesconto(pedido.CalcularPrecoTotal());
                    pedido.ValorFinal = valorDescontado;
                    Console.WriteLine($"\nFoi aplicado um desconto de:{(pedido.CalcularPrecoTotal() - pedido.ValorFinal)}.");
                    pedidoNaoEncontrado = false;
                    break;
                }
            }

            if (pedidoNaoEncontrado)
            {
                Console.WriteLine("ID informado inválido.");
            }

        }

    }
}
