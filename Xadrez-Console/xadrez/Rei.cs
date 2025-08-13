using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaXadrez game;
        private bool ignorarRoque = false;
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez game) : base(tab, cor)
        {
            this.game = game;
        }

        private bool testeTorre(Posicao pos)
        {
            Peca p = Tab.getPeca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
        }

        private bool TesteAmeaca(Posicao pos)
        {
            foreach (Peca p in game.pecasInGame(game.adversaria(Cor)))
            {
                bool[,] mat;

                if (p is Rei rei)
                    mat = rei.MovesPossiblesInterno(true); // ignora roque
                else
                    mat = p.MovesPossibles();

                if (mat[pos.Linha, pos.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public override bool[,] MovesPossibles()
        {
            return MovesPossiblesInterno(false);
        }

        private bool[,] MovesPossiblesInterno(bool ignorarRoque)
        {
            bool[,] mat = new bool[Tab.Linha, Tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Acima-direita
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // Acima-esquerda
            pos.ChangeValue(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.ChangeValue(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.ChangeValue(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo-esquerda
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo-direita
            pos.ChangeValue(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && MovePermission(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #Jogada Especial Roque
            if (!ignorarRoque && QtdMovimentos == 0 && !game.Xeque && !TesteAmeaca(Posicao))
                {
                // Roque pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (testeTorre(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tab.getPeca(p1) == null && !TesteAmeaca(p1) &&
                        Tab.getPeca(p2) == null && !TesteAmeaca(p2))
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Roque grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (testeTorre(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.getPeca(p1) == null && !TesteAmeaca(p1) &&
                        Tab.getPeca(p2) == null && !TesteAmeaca(p2) &&
                        Tab.getPeca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

                return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
