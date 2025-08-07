﻿using BoardExceptions;
using System.Net.Security;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Pecas = new Peca[linha, coluna];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = Peca(pos);
                aux.Posicao = null;
                Pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return Peca(pos) != null;
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.Linha<0 || pos.Linha >= Linha || pos.Coluna<0 || pos.Coluna >= Coluna)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }

    }
}
