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

                        Console.WriteLine("Turno: " + game.turno);
                        Console.WriteLine("Aguardando jogada: " + game.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.ReadPosition().toPosicao();
                        game.ValidarPosOrigem(origem);

                        bool[,] possiblePositions = game.tab.getPeca(origem).MovesPossibles();

                        Console.Clear();
                        Tela.PrintBoard(game.tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.ReadPosition().toPosicao();
                        game.ValidarPosDestino(origem, destino);
                        game.RealizarJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.Write(e.Message);
                        Console.Write(" Aperte [Enter] para refazer a jogada!");
                        Console.ReadLine();
                    }
                }
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
