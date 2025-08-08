namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdMovimentos = 0;
        }

        protected bool MovePermission(Posicao pos)
        {
            Peca p = Tab.getPeca(pos);
            return p == null || p.Cor != Cor;
        }
        public abstract bool[,] MovesPossibles();

        public void incrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public bool existeMovesPossibles()
        {
            bool[,] mat = MovesPossibles();
            for(int i = 0; i < Tab.Linha; i++)
            {
                for(int j = 0; j < Tab.Coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Posicao pos)
        {
            return MovesPossibles()[pos.Linha, pos.Coluna];
        }
    }
}
