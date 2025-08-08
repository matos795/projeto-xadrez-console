using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using tabuleiro;
using xadrez;

namespace Xadrez_Console.Extensions
{
    internal class Tela
    {
        public static void PrintGame(PartidaXadrez game)
        {
            PrintCapturedPecas(game);
            Console.WriteLine("Turno: " + game.turno);
            Console.WriteLine("Aguardando jogada: " + game.jogadorAtual);
        }

        public static void PrintCapturedPecas(PartidaXadrez game)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            PrintConjunto(game.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintConjunto(game.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + ", ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Tabuleiro tab)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoNovo = ConsoleColor.Red;

            for (int i = 0; i < tab.Linha; i++)
            {

                Console.Write((8 - i) + " ");
                if (i == 0)
                {
                    Console.BackgroundColor = fundoOriginal;
                }

                for (int j = 0; j < tab.Coluna; j++)
                {
                        PrintColors(i, j);
                        PrintPeca(tab.getPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
            Console.WriteLine();
        }

        public static void PrintBoard(Tabuleiro tab, bool[,] movesPossibles)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoNovo = ConsoleColor.DarkRed;

            for (int i = 0; i < tab.Linha; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {
                    
                    if (movesPossibles[i, j])
                    {
                        Console.BackgroundColor = fundoNovo;
                    }
                    else
                    {
                        PrintColors(i, j);
                    }
                    
                    PrintPeca(tab.getPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
            Console.WriteLine();
        }

        public static PosicaoXadrez ReadPosition()
        {
            string x = Console.ReadLine();
            char column = x[0];
            int line = int.Parse(x[1] + "");
            return new PosicaoXadrez(column, line);
        }

        public static void PrintColors(int i, int j)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoBranco = ConsoleColor.DarkGray;
            int x = 0;

            do
            {
                if ((i % 2) == (j % 2))
                {
                    Console.BackgroundColor = fundoBranco;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                x++;
            } while (x % 2 == 1);

            do
            {
                if ((i % 2) != (j % 2))
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                else
                {
                    Console.BackgroundColor = fundoBranco;
                }
                x++;
            } while (x % 2 == 0);
        }

        public static void PrintPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("   ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" " + peca + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" " + peca + " ");
                    Console.ResetColor();
                }
            }
        }

    }
}
