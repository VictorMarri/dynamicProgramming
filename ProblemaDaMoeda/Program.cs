using System;
using System.Collections.Generic;

namespace ProblemaDaMoeda
{
    public class Moeda
    {
        public int Valor { get; set; }

        public Moeda(int valor)
        {
            Valor = valor;
        }
    }

    public class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            List<int> valoresParaTroco = new List<int> { 9, 13, 17, 20 };
            
            int valorParaTroco = valoresParaTroco[rnd.Next(valoresParaTroco.Count)];

            List<Moeda> itens = new List<Moeda>();
            itens.Add(new Moeda(15));
            itens.Add(new Moeda(10));
            itens.Add(new Moeda(5));
            itens.Add(new Moeda(3));
            itens.Add(new Moeda(1));

            ProgramacaoDinamica(itens, valorParaTroco);

            Console.ReadKey();
        }

        private static void ProgramacaoDinamica(List<Moeda> itens, int valorParaTroco)
        {
            //                        Linha         Colunas
            int[,] tabela = new int[itens.Count, valorParaTroco + 1];

            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                tabela[0, j] = j;
            }

            //Prenchendo as proximas linhas da tabela (Começa na linha 1 pq a zero eu ja preenchi)
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                //GetLength(1) -> Pegando o tamanho colunas
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < itens[i].Valor)
                    {
                        tabela[i, j] = tabela[i - 1, j];
                    }
                    else
                    {
                        tabela[i, j] = Math.Min(tabela[i - 1, j], tabela[i, j - itens[i].Valor] + 1);
                    }
                }

            }

            ImprimirTabela(tabela);
        }

        private static void ImprimirTabela(int[,] tabela)
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
