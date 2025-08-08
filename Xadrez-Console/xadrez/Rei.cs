using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] MovesPossibles()
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
            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
