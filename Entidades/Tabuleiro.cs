using System;
using System.Text;

namespace JogoVelha.Entidades
{
	public class Tabuleiro
	{
		public bool Partida { get; set; }
		private string[,] Espaco { get; set; } = new string[3,3];

		private int _jogadorAtual = 1;

		public Jogador[] Jogadores { get; private set; } = new Jogador[2];

		public int JogadorAtual
		{
			get
			{
				_jogadorAtual = (_jogadorAtual == 0) ? 1 : 0;
				return _jogadorAtual;
			}
		}

		public Tabuleiro(Jogador jogador1, Jogador jogador2)
		{
			Jogadores[0] = jogador1;
			Jogadores[1] = jogador2;

			Partida = true;
		}

		public override string ToString()
		{
			StringBuilder retorno = new();

			retorno.AppendLine("  1 2 3");

			for (int linha = 0; linha < Espaco.GetLength(0); linha++)
			{

				retorno.Append($"{linha + 1} ");

				for (int coluna = 0; coluna < Espaco.GetLength(1); coluna++)
				{
					retorno.Append($"{Espaco[linha, coluna] ?? " "} ");
				}

				retorno.AppendLine();

			}

			return retorno.ToString();
		}

		public bool FazerJogada(Jogador jogadorSelecionado, string jogadaPosicoes)
		{
			string[] posicoes = jogadaPosicoes.Split();

			int linhaSelecionada;
			int colunaSelecionada;

			try
			{
				linhaSelecionada = int.Parse(posicoes[0]);
				colunaSelecionada = int.Parse(posicoes[1]);

				linhaSelecionada--;
				colunaSelecionada--;

				linhaSelecionada = (linhaSelecionada >= 0 && linhaSelecionada <= 2) ? linhaSelecionada : 0;
				colunaSelecionada = (colunaSelecionada >= 0 && colunaSelecionada <= 2) ? colunaSelecionada : 0;

			}
			catch (FormatException)
			{
				return false;
			}

			if (Espaco[linhaSelecionada, colunaSelecionada] == null!)
			{
				Espaco[linhaSelecionada, colunaSelecionada] = jogadorSelecionado.Simbolo;
				return true;
			}
			else return false;
		}

		public bool ChecarGanhador(Jogador jogadorSelecionado)
		{

			for (int linha = 0; linha < Espaco.GetLength(0); linha++)
			{
				if (Espaco[linha, 0] == jogadorSelecionado.Simbolo && (Espaco[linha, 0] == Espaco[linha, 1]) && (Espaco[linha, 1] == Espaco[linha, 2]))
				{
					return true;
				}
			}

			for (int coluna = 0; coluna < Espaco.GetLength(0); coluna++)
			{
				if (Espaco[0, coluna] == jogadorSelecionado.Simbolo && (Espaco[0, coluna] == Espaco[1, coluna]) && (Espaco[1, coluna] == Espaco[2, coluna]))
				{
					return true;
				}
			}

			if (Espaco[0, 0] == jogadorSelecionado.Simbolo && (Espaco[0, 0] == Espaco[1, 1]) && (Espaco[1, 1] == Espaco[2, 2]))
			{
				return true;
			}

			if (Espaco[0, 2] == jogadorSelecionado.Simbolo && (Espaco[0, 2] == Espaco[1, 1]) && (Espaco[1, 1] == Espaco[2, 0]))
			{
				return true;
			}

			return false;
		}

		public bool ChecarVelha()
		{
			int espacosOcupados = 0;

			for (int linha = 0; linha < Espaco.GetLength(0); linha++)
			{
				for (int coluna = 0; coluna < Espaco.GetLength(1); coluna++)
				{
					if (Espaco[linha, coluna] != null!) espacosOcupados++;
				}
			}

			if (espacosOcupados == Espaco.Length) return true;
			else return false;
		}

		public void IniciarPartida()
		{
			_jogadorAtual = 1;
			Partida = true;
			Espaco = new string[3, 3];
		}

	}
}
