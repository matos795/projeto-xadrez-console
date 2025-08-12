using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        private bool existEnemy(Posicao pos)
        {
            Peca p = Tab.getPeca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tab.getPeca(pos) == null;
        }

        public override bool[,] MovesPossibles()
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];
            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {
                pos.ChangeValue(Posicao.Linha -1, Posicao.Coluna); 
                if(Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existEnemy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && existEnemy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existEnemy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && existEnemy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
                return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
