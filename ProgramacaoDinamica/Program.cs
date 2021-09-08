using System;
using System.Collections.Generic;

namespace ProgramacaoDinamica
{
    class Program
    {
        public class Item
        {
            public int Peso { get; set; }
            public int Valor { get; set; }

            public Item(int peso, int valor)
            {
                Peso = peso;
                Valor = valor;
            }

        }

        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(3, 4));
            itens.Add(new Item(4, 5));
            itens.Add(new Item(5, 8));
            itens.Add(new Item(7, 10));
            int capacidadeMochila = 10;

            ProgramacaoDinamicaSemRepeticao(itens, capacidadeMochila);

            Console.WriteLine("\n\n");

            ProgramacaoDinamicaComRepeticao(itens, capacidadeMochila);

            Console.ReadKey();
        }

        static void ProgramacaoDinamicaSemRepeticao(List<Item> itens, int capacidadeMochila)
        {
            int[,] tabela = new int[itens.Count, capacidadeMochila+1];

            //Preenchimento da primeira linha
            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < itens[0].Peso)
                {
                    tabela[0, j] = 0;
                }
                else
                {
                    tabela[0, j] = itens[0].Valor; 
                }
            }

            //Prenchendo as proximas linhas da tabela (Começa na linha 1 pq a zero eu ja preenchi)
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].Peso)
                    {
                        tabela[i, j] = tabela[i - 1, j];
                    }
                    else
                    {
                        tabela[i, j] = Math.Max(tabela[i - 1, j], tabela[i - 1, j - itens[i].Peso] + itens[i].Valor);
                    }
                }

            }
                    ImprimirTabela(tabela);
        }

        static void ProgramacaoDinamicaComRepeticao(List<Item> itens, int capacidadeMochila)
        {
            int[,] tabela = new int[itens.Count, capacidadeMochila + 1];

            //Preenchimento da primeira linha
            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < itens[0].Peso)
                {
                    tabela[0, j] = 0;
                }
                else
                {
                    tabela[0, j] = tabela[0 , j - itens[0].Peso] + itens[0].Valor;
                }
            }

            //Prenchendo as proximas linhas da tabela (Começa na linha 1 pq a zero eu ja preenchi)
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].Peso)
                    {
                        tabela[i, j] = tabela[i - 1, j];
                    }
                    else
                    {
                        tabela[i, j] = Math.Max(tabela[i - 1, j], tabela[i, j - itens[i].Peso] + itens[i].Valor);
                    }
                }

            }
            ImprimirTabela(tabela);
        }

        private static void ImprimirTabela(int[,] tabela)
        {
            for (int i = 0; i < tabela.GetLength(1); i++)
            {
                Console.Write(i +" ");
            }
            Console.WriteLine();

            //GetLength(0) -> Pegando o tamanho linhas
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(tabela[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
