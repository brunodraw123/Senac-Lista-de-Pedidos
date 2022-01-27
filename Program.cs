using System;
using System.Collections.Generic;

namespace atividade1
{
    class ItemPedido //classe referente às características de um item
    {
        public string descricao { get; set; }//atributos de um item
        public float valor_unitario { get; set; }
        public float quantidade { get; set; }
        public float valor_total_item { get; set; }//contabiliza o valor total por linha
        public ItemPedido(string Descricao, float Valor_unitario, float Quantidade, float Valor_total_item)//construtor
        {
            descricao = Descricao;
            valor_unitario = Valor_unitario;
            quantidade = Quantidade;
            valor_total_item = Valor_total_item;
        }
    }
    class Pedido //classe que elaborara a lsta
    {
        public static List<ItemPedido> lista = new List<ItemPedido>();
        public static void Incluir(ItemPedido novoItem)//metodo que inclui itens na lista
        {

            lista.Add(novoItem);//adiciona na lista cada novo item 
        }
        public static float valor_total_pedido { get; set; } = 0;

    }


    class Program//classe principal(executadora do programa)
    {
        public static void Menu()
        {
            char condicao = 's';
            Console.Clear();//limpa dados do console

            Console.WriteLine(" == SOFTWARE DE PEDIDOS ==");
            Console.WriteLine("Seja bem vindo e monte seu pedido como deseja!");

            while (condicao == 's')
            {
                Console.WriteLine("-Descrição do produto-");
                string _descricao = Console.ReadLine();
                //
                Console.WriteLine("Valor unitário:");
                float _valorUni = float.Parse(Console.ReadLine());
                //
                Console.WriteLine("Quantidade:");
                float _quantidade = float.Parse(Console.ReadLine());
                //
                float _valorTotalUni = _valorUni * _quantidade;//valor total de cada item
                Pedido.valor_total_pedido = Pedido.valor_total_pedido + _valorTotalUni;//Valor total final;
                ItemPedido item = new ItemPedido(_descricao, _valorUni, _quantidade, _valorTotalUni);//por meio da criação de objetos usamos as clases
                Pedido.Incluir(item);//]
                //
                Console.WriteLine("Deseja continuar ?(s/n)");
                condicao = char.Parse(Console.ReadLine());

            }
            Console.WriteLine("-LISTA FINAL-");

            foreach (ItemPedido _item in Pedido.lista)
            {
                Console.WriteLine($"{_item.descricao} ---- R${_item.valor_unitario}/un ---- {_item.quantidade} unidade(s) ---- Total R${_item.valor_total_item}");

            }
            Console.WriteLine($"Valor total do pedido: R${Pedido.valor_total_pedido}");
        }
        static void Main(String[] args)//metodo principal do programa(executador do programa)
        {
            Menu();
        }
    }
}
