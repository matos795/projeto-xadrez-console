using BoardExceptions;
using System;
using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            setAllPecas();
        }

        public void Movimentar(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Movimentar(origem, destino);
            turno++;
            changePlayer();
        }

        public void ValidarPosOrigem(Posicao pos)
        {
            if(tab.getPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != tab.getPeca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.getPeca(pos).existeMovesPossibles())
            {
                throw new TabuleiroException("Não há movimentos para a peça escolhida!");
            }
        }

        public void ValidarPosDestino(Posicao origem, Posicao destino)
        {
            if (!tab.getPeca(origem).CanMoveTo(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void changePlayer()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void setAllPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
