using System;
using System.Collections.Generic;

namespace PrblemaDoCaminhao
{
    class Program
    {
        public class Item
        {
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public double Beneficio { get; set; }

            public Item(string nome, int quantidade, double beneficio)
            {
                Nome = nome;
                Quantidade = quantidade;
                Beneficio = beneficio;
            }
        }

        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item("Cimento", 3, 13));
            itens.Add(new Item("Cal", 3, 11.5));
            itens.Add(new Item("Madeira", 4, 11.5));
            itens.Add(new Item("Ferro", 8, 10));
            itens.Add(new Item("Areia", 12, 8));
            itens.Add(new Item("Pedra", 12, 7));
            int capacidadeCaminhao = 20;

            ProgramacaoDinamicaSemRepeticao(itens, capacidadeCaminhao);

            Console.WriteLine("\n\n");

            Console.ReadKey();
        }

        static void ProgramacaoDinamicaSemRepeticao(List<Item> itens, int capacidadeCaminhao)
        {
            double[,] tabela = new double[itens.Count, capacidadeCaminhao + 1];

            //Preenchimento da primeira linha
            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < itens[0].Quantidade)
                {
                    tabela[0, j] = 0;
                }
                else
                {
                    tabela[0, j] = itens[0].Beneficio;
                }
            }

            //Prenchendo as proximas linhas da tabela (Começa na linha 1 pq a zero eu ja preenchi)
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].Quantidade)
                    {
                        tabela[i, j] = tabela[i - 1, j];
                    }
                    else
                    {
                        tabela[i, j] = Math.Max(tabela[i - 1, j], tabela[i - 1, j - itens[i].Quantidade] + itens[i].Beneficio);
                    }
                }

            }
            ImprimirTabela(tabela);
        }


        private static void ImprimirTabela(double[,] tabela)
        {
            for (int i = 0; i < tabela.GetLength(1); i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //GetLength(0) -> Pegando o tamanho linhas
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(tabela[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
