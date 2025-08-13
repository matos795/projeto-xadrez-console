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
        public bool Xeque { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            TotalPecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            Xeque = false;
            setAllPecas();
        }

        public Peca Movimentar(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pCapturada != null)
            {
                Capturadas.Add(pCapturada);
            }

            // # ROQUE PEQUENO 

            if(p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Peca t = tab.retirarPeca(new Posicao(p.Posicao.Linha, p.Posicao.Coluna + 1));
                t.incrementarQtdMovimentos();
                tab.colocarPeca(t, new Posicao(p.Posicao.Linha, p.Posicao.Coluna - 1));
            }

            // # ROQUE GRANDE
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Peca t = tab.retirarPeca(new Posicao(p.Posicao.Linha, p.Posicao.Coluna - 2));
                t.incrementarQtdMovimentos();
                tab.colocarPeca(t, new Posicao(p.Posicao.Linha, p.Posicao.Coluna + 1));
            }
            return pCapturada;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasInGame(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool InXeque(Cor cor)
        {
            Peca R = rei(cor);
            if(rei(cor) == null)
            {
                throw new TabuleiroException("Um rei está faltando ao tabuleiro!");
            }

            foreach (Peca p in pecasInGame(adversaria(cor)))
            {
                bool[,] mat = p.MovesPossibles();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestXequeMate(Cor cor)
        {
            if (!InXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasInGame(cor))
            {
                bool[,] mat = x.MovesPossibles();
                for(int i = 0; i < tab.Linha; i++)
                {
                    for(int j = 0; j < tab.Coluna; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = Movimentar(origem, destino);
                            bool testeXeque = InXeque(cor);
                            cancelMove(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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

        public void cancelMove(Posicao origem, Posicao destino, Peca pCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pCapturada != null)
            {
                tab.colocarPeca(pCapturada, destino);
                Capturadas.Remove(pCapturada);
            }

            // # ROQUE PEQUENO 

            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Peca t = tab.retirarPeca(new Posicao(destino.Linha, destino.Coluna - 1));
                t.decrementarQtdMovimentos();
                tab.colocarPeca(t, new Posicao(destino.Linha, destino.Coluna + 1));
            }

            // # ROQUE GRANDE
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Peca t = tab.retirarPeca(new Posicao(destino.Linha, destino.Coluna + 1));
                t.decrementarQtdMovimentos();
                tab.colocarPeca(t, new Posicao(destino.Linha, destino.Coluna - 2));
            }

            tab.colocarPeca(p, origem);
        }
        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Peca pCap = Movimentar(origem, destino);

            if (InXeque(jogadorAtual))
            {
                cancelMove(origem, destino, pCap);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (InXeque(adversaria(jogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                changePlayer();
            }
        }

        public void ValidarPosOrigem(Posicao pos)
        {
            if (tab.getPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (jogadorAtual != tab.getPeca(pos).Cor)
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
            if (jogadorAtual == Cor.Branca)
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

            setNewPeca('a', 1, new Torre(tab, Cor.Branca));
            setNewPeca('b', 1, new Cavalo(tab, Cor.Branca));
            setNewPeca('c', 1, new Bispo(tab, Cor.Branca));
            setNewPeca('d', 1, new Dama(tab, Cor.Branca));
            setNewPeca('e', 1, new Rei(tab, Cor.Branca, this));
            setNewPeca('f', 1, new Bispo(tab, Cor.Branca));
            setNewPeca('g', 1, new Cavalo(tab, Cor.Branca));
            setNewPeca('h', 1, new Torre(tab, Cor.Branca));
            setNewPeca('a', 2, new Peao(tab, Cor.Branca));
            setNewPeca('b', 2, new Peao(tab, Cor.Branca));
            setNewPeca('c', 2, new Peao(tab, Cor.Branca));
            setNewPeca('d', 2, new Peao(tab, Cor.Branca));
            setNewPeca('e', 2, new Peao(tab, Cor.Branca));
            setNewPeca('f', 2, new Peao(tab, Cor.Branca));
            setNewPeca('g', 2, new Peao(tab, Cor.Branca));
            setNewPeca('h', 2, new Peao(tab, Cor.Branca));


            setNewPeca('a', 8, new Torre(tab, Cor.Preta));
            setNewPeca('b', 8, new Cavalo(tab, Cor.Preta));
            setNewPeca('c', 8, new Bispo(tab, Cor.Preta));
            setNewPeca('d', 8, new Dama(tab, Cor.Preta));
            setNewPeca('e', 8, new Rei(tab, Cor.Preta, this));
            setNewPeca('f', 8, new Bispo(tab, Cor.Preta));
            setNewPeca('g', 8, new Cavalo(tab, Cor.Preta));
            setNewPeca('h', 8, new Torre(tab, Cor.Preta));
            setNewPeca('a', 7, new Peao(tab, Cor.Preta));
            setNewPeca('b', 7, new Peao(tab, Cor.Preta));
            setNewPeca('c', 7, new Peao(tab, Cor.Preta));
            setNewPeca('d', 7, new Peao(tab, Cor.Preta));
            setNewPeca('e', 7, new Peao(tab, Cor.Preta));
            setNewPeca('f', 7, new Peao(tab, Cor.Preta));
            setNewPeca('g', 7, new Peao(tab, Cor.Preta));
            setNewPeca('h', 7, new Peao(tab, Cor.Preta));
        }
    }
}
