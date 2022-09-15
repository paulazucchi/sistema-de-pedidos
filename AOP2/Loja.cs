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
        private Funcionario funcionario = new Gerente();


        public Loja()
        {
            listaPedidos = new List<Pedido>();
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
                        loja.inserirPedido();
                        break;
                    case 2:
                        loja.buscarPedido();
                        break;
                    case 3:
                        loja.removerPedido();
                        break;
                    case 4:
                        loja.exibirPedidos();
                        break;
                    case 0:
                        Console.WriteLine("Até mais...");
                        break;
                    default:
                        Console.WriteLine("Opção invalida!");
                        break;

                }


            } while (opcao != 0);


            _ = Console.ReadKey();
        }

        public void Menu()
        {
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1 - Inserir Pedido");
            Console.WriteLine("2 - Buscar Pedido");
            Console.WriteLine("3 - Remover Pedido");
            Console.WriteLine("4 - Exibir Pedido");
            Console.WriteLine("0 - Sair");
        }

        public void inserirPedido()
        {
            //criar uma função ou inserir aqui a captura das informações dos produtos que serão inseridos
            
            int novoId = this.listaPedidos.Count + 1;
            Pedido p = new Pedido(novoId, 10.99f, $"Produto {novoId}");
            
            listaPedidos.Add(p);
            Console.WriteLine("Pedido Inserido com sucesso.");
        }

        public void buscarPedido()
        {
            Console.Write("Informe o id do pedido: ");
            int buscarId = int.Parse(Console.ReadLine());

            if(buscarId>0 && buscarId <= listaPedidos.Count)
            {
                
                //Pedido pedido = listaPedidos.ElementAt<Pedido>(buscarId-1);

                Console.WriteLine($"Pedido : {buscarId}");
                Pedido pedido = listaPedidos[buscarId-1];
                Console.WriteLine(pedido.ToString());
            }
            else
            {
                Console.WriteLine("Id invalido!");
            }

        }

        public void removerPedido()
        {
            Console.Write("Informe o id do pedido: ");
            int buscarId = int.Parse(Console.ReadLine());

            if (buscarId > 0 && buscarId <= listaPedidos.Count)
            {
                Console.WriteLine($"Pedido : {buscarId}");
                listaPedidos.RemoveAt(buscarId-1);
                Console.WriteLine($"Pedido {buscarId}  Removido com Sucesso");
            }
            else
            {
                Console.WriteLine("Id invalido!");
            }
        }

        public void exibirPedidos()
        {
            foreach(Pedido p in listaPedidos)
            {
                Console.WriteLine(p.ToString());
            }
        }


    }
}
