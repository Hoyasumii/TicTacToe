using System;

using JogoVelha.Entidades;

namespace JogoVelha
{
	public class Program
	{ 
		// TODO: Estruturar melhor o projeto para publicar no GitHub

		public static void Main()
		{
			string[] simbolos = { "O", "X" };

			int simboloJogadorInicial;

			Jogador jogadorAtual = null!;
			int jogadorAtualPosicao;

			string jogadaTexto = null!;
			bool jogadaStatus;

			int continuar = 1;

			Console.WriteLine("Bem vindo ao Jogo da Velha");

			Console.WriteLine("Informe o símbolo do jogador 1:");

			for (int item = 0; item < simbolos.Length; item++)
			{
				Console.WriteLine($"\t[{item + 1}] {simbolos[item]}");
			}

			Console.Write("Informe a resposta: ");
			simboloJogadorInicial = int.Parse(Console.ReadLine()!) - 1;
			simboloJogadorInicial = (simboloJogadorInicial > 0 && simboloJogadorInicial <= 2) ? simboloJogadorInicial : 0;

			Tabuleiro jogo = new(new(simbolos[simboloJogadorInicial]), new(simbolos[(simboloJogadorInicial == 1) ? 0 : 1]));

			while (continuar == 1)
			{
				jogo.IniciarPartida();
				
				Console.Clear();

				Console.WriteLine($"\nPONTUAÇÃO:" +
					$"\nJogador 1: {jogo.Jogadores[0].Pontuacao}" +
					$"\nJogador 2: {jogo.Jogadores[1].Pontuacao}\n");

				Console.WriteLine("Pressione QUALQUER TECLA para começar");
				Console.WriteLine("Dica: Quando for mencionar a posição X e Y do tabuleiro, separe as duas coordenadas pelo espaço");
				Console.WriteLine("Dica: As posições são do tipo linha coluna");
				Console.ReadKey();

				while (jogo.Partida)
				{
					Console.Clear();

					Console.Write(jogo);

					jogadorAtualPosicao = jogo.JogadorAtual;

					jogadaStatus = false;

					jogadorAtual = jogo.Jogadores[jogadorAtualPosicao];

					while (!jogadaStatus)
					{
						Console.Write($"Agora é a vez do Jogador {jogadorAtualPosicao + 1}: ");
						jogadaTexto = Console.ReadLine()!;

						if (jogadaTexto.Contains(' '))
						{
							jogadaStatus = jogo.FazerJogada(jogadorAtual, jogadaTexto);
						}
					}

					jogo.Partida = !jogo.ChecarGanhador(jogadorAtual);

					if (jogo.Partida)
					{
						jogo.Partida = !jogo.ChecarVelha();
						jogadorAtual = null!;
					}

				}

				if (jogadorAtual != null!)
				{
					Console.WriteLine(jogadorAtual);
					jogadorAtual.AumentarPontuacao();
				}
				else
				{
					Console.WriteLine("Resultado do jogo: Empate");
				}

				Console.Write("Deseja continuar (1 para sim; 0 para não)? ");
				continuar = int.Parse(Console.ReadLine()!);
				continuar = (continuar == 0 || continuar == 1) ? continuar : 0;

			}

			Console.Clear();

			Console.WriteLine($"\nPONTUAÇÃO FINAL:" +
					$"\nJogador 1: {jogo.Jogadores[0].Pontuacao}" +
					$"\nJogador 2: {jogo.Jogadores[1].Pontuacao}\n");

		}

			


	}
}