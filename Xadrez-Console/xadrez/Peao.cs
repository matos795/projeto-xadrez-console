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
        private PartidaXadrez game;
        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez game) : base(tab, cor)
        {
            this.game = game;
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

                // # EN PASSANT

                if(Posicao.Linha == 3)
                {
                    Posicao leftPosition = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao rightPosition = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tab.posicaoValida(leftPosition) && existEnemy(leftPosition) && Tab.getPeca(leftPosition) == game.vulneravelEnPassant)
                    {
                        mat[leftPosition.Linha - 1, leftPosition.Coluna] = true;
                    } 
                    else if(Tab.posicaoValida(rightPosition) && existEnemy(rightPosition) && Tab.getPeca(rightPosition) == game.vulneravelEnPassant)
                    {
                        mat[rightPosition.Linha - 1, rightPosition.Coluna] = true;
                    }
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

                // # EN PASSANT

                if (Posicao.Linha == 4)
                {
                    Posicao leftPosition = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao rightPosition = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tab.posicaoValida(leftPosition) && existEnemy(leftPosition) && Tab.getPeca(leftPosition) == game.vulneravelEnPassant)
                    {
                        mat[leftPosition.Linha + 1, leftPosition.Coluna] = true;
                    }
                    if (Tab.posicaoValida(rightPosition) && existEnemy(rightPosition) && Tab.getPeca(rightPosition) == game.vulneravelEnPassant)
                    {
                        mat[rightPosition.Linha + 1, rightPosition.Coluna] = true;
                    }
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
