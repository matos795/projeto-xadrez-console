using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using Xadrez_Console.Extensions;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Console.WriteLine("Aperte (Enter) para iniciar o jogo!");
            Console.ReadLine();
            Tela.PrintBoard(tab);
        }
    }
}
