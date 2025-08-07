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

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));
                Tela.PrintBoard(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
