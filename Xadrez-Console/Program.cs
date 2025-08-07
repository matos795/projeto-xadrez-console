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
                PartidaXadrez game = new PartidaXadrez();

                while (!game.terminada)
                {
                    Console.Clear();
                    Tela.PrintBoard(game.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.ReadPosition().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.ReadPosition().toPosicao();
                    game.Movimentar(origem, destino);
                }
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
