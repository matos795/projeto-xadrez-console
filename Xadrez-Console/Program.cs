using System;
using tabuleiro;
using Xadrez_Console.Extensions;
using xadrez;
using BoardExceptions;


namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aperte (Enter) para iniciar o jogo!");
            Console.ReadLine();

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                Tela.PrintBoard(tab);

                PosicaoXadrez p = new PosicaoXadrez('c', 7);
                Console.WriteLine(p);
                Console.WriteLine(p.toPosicao());
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
