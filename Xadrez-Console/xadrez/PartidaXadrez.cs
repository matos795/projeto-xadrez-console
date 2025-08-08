using BoardExceptions;
using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> TotalPecas;
        private HashSet<Peca> Capturadas;

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            TotalPecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            setAllPecas();
        }

        public void Movimentar(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pCapturada != null)
            {
                Capturadas.Add(pCapturada);
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            } return aux;
        }

        public HashSet<Peca> pecasInGame(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in TotalPecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
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

        public void setNewPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            TotalPecas.Add(peca);
        }

        private void setAllPecas()
        {

            setNewPeca('c', 1, new Torre(tab, Cor.Branca));
            setNewPeca('c', 2, new Torre(tab, Cor.Branca));
            setNewPeca('d', 2, new Torre(tab, Cor.Branca));
            setNewPeca('e', 2, new Torre(tab, Cor.Branca));
            setNewPeca('e', 1, new Torre(tab, Cor.Branca));
            setNewPeca('d', 1, new Rei(tab, Cor.Branca));

            setNewPeca('c', 7, new Torre(tab, Cor.Preta));
            setNewPeca('c', 8, new Torre(tab, Cor.Preta));
            setNewPeca('d', 7, new Torre(tab, Cor.Preta));
            setNewPeca('e', 7, new Torre(tab, Cor.Preta));
            setNewPeca('e', 8, new Torre(tab, Cor.Preta));
            setNewPeca('d', 8, new Rei(tab, Cor.Preta));
        }
    }
}
