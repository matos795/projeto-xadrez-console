using System;
using tabuleiro;
using Xadrez_Console.Extensions;
using xadrez;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

            Console.WriteLine("Aperte (Enter) para iniciar o jogo!");
            Console.ReadLine();
            Tela.PrintBoard(tab);
        }
    }
}
