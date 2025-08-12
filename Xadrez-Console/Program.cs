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
                    try
                    {
                        Console.Clear();
                        Tela.PrintBoard(game.tab);
                        Tela.PrintGame(game);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.ReadPosition().toPosicao();
                        game.ValidarPosOrigem(origem);

                        bool[,] possiblePositions = game.tab.getPeca(origem).MovesPossibles();

                        Console.Clear();
                        Tela.PrintBoard(game.tab, possiblePositions);
                        Tela.PrintGame(game);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.ReadPosition().toPosicao();
                        game.ValidarPosDestino(origem, destino);
                        game.RealizarJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.Write(e.Message);
                        Console.Write(" Aperte [Enter] para refazer a jogada! ");
                        Console.ForegroundColor = aux;
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.PrintBoard(game.tab);
                Tela.PrintGame(game);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
