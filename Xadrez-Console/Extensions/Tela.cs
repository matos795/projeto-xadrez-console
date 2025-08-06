using System;
using tabuleiro;

namespace Xadrez_Console.Extensions
{
    internal class Tela
    {
        public static void PrintBoard(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linha; i++)
            {
                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
