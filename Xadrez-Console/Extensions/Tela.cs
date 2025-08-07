using System;
using System.Security.Authentication.ExtendedProtection;
using tabuleiro;
using xadrez;

namespace Xadrez_Console.Extensions
{
    internal class Tela
    {
        public static void PrintBoard(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linha; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                       PrintPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez ReadPosition()
        {
            string x = Console.ReadLine();
            char column = x[0];
            int line = int.Parse(x[1] + "");
            return new PosicaoXadrez(column, line);
        }

        public static void PrintPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ResetColor();
            }
        }

    }
}
