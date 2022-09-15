using System;

namespace JogoVelha.Entidades
{
	public class Jogador
	{
		public string Simbolo { get; private set; } = null!;
		public int Pontuacao { get; private set; }

		public Jogador(string simbolo)
		{
			Simbolo = simbolo;
			Pontuacao = 0;
		}

		public void AumentarPontuacao() => Pontuacao++;

		public override string ToString()
		{
			return $"O jogador possuidor do símbolo {Simbolo} venceu a partida!";
		}

	}
}
