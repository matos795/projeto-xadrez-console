using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] MovesPossibles()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            // Diagonal cima-esquerda
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna -= 1;
            }

            // Acima-direita
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna += 1;
            }

            // Abaixo-esquerda
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna -= 1;
            }

            // Abaixo-direita
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna += 1;
            }

            //Todos abaixo
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha += 1;
            }

            //Todos acima
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Linha -= 1;
            }

            //Todos esquerda
            pos.ChangeValue(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null)
                {
                    break;
                }
                pos.Coluna -= 1;
            }

            //Todos direita
            pos.ChangeValue(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.getPeca(pos) != null && Tab.getPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna += 1;
            }

            return mat;
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
