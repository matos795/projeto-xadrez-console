using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] MovesPossibles()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            // Acima-cima-esquerda
            pos.ChangeValue(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Acima-baixo-esquerda
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Acima-cima-direita
            pos.ChangeValue(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Acima-baixo-direita
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Abaixo-cima-esquerda
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Abaixo-baixo-esquerda
            pos.ChangeValue(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Abaixo-cima-direita
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo-direita
            pos.ChangeValue(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
