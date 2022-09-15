using System;

using TicTacToe.Entities;

namespace TicTacToe
{
	public class Program
	{

		public static Game Game { get; set; } = null!;

		public static Player ActualPlayer { get; set; } = null!;

		public static void Main()
		{
			ConsoleKeyInfo runningGame = new('Y', ConsoleKey.Y, false, false, false);

			Console.WriteLine("WELCOME TO THE TIC-TAC-TOE GAME\n");

			Console.Write("X or O? ");

			ConsoleKeyInfo firstPlayerSymbol = Console.ReadKey(true);
			firstPlayerSymbol = (firstPlayerSymbol.KeyChar == 'O' || firstPlayerSymbol.KeyChar == 'X') ? firstPlayerSymbol : new ConsoleKeyInfo('O', ConsoleKey.O, false, false, false);

			Game = new(new("Player 1", firstPlayerSymbol.KeyChar.ToString()), new("Player 2", (firstPlayerSymbol.KeyChar == 'O') ? "X" : "O"));

			while (runningGame.Key == ConsoleKey.Y)
			{
				Game.StartGame();

				Console.Clear();

				Console.WriteLine(ShowScore());

				Console.Write("PRESS ANY KEY TO START");

				Console.ReadKey(true);

				Run();
				EndingGame();

				Console.Write("KEEP RUNNING? (Y/ANY) ");

				runningGame = Console.ReadKey();
			}

			Console.Clear();
			Console.WriteLine(ShowScore(true));

		}

		public static void Run()
		{
			int actualPlayerPosition;
			bool moveMade;

			while (Game.Running)
			{
				Console.Clear();

				Console.Write($"\n{Game}\n");

				actualPlayerPosition = Game.ActualPlayer;

				moveMade = false;

				ActualPlayer = Game.Players[actualPlayerPosition];

				while (!moveMade)
				{
					Console.WriteLine($"NOW IT'S THE {ActualPlayer.Name}({ActualPlayer.Symbol}) TURN: ");

					Console.Write("LINE: ");
					ConsoleKeyInfo selectedLine = Console.ReadKey(true);
					Console.WriteLine(selectedLine.KeyChar);

					Console.Write("COLUMN: ");
					ConsoleKeyInfo selectedColumn = Console.ReadKey(true);
					Console.WriteLine(selectedColumn.KeyChar);

					try
					{
						moveMade = Game.Move(ActualPlayer, int.Parse(selectedLine.KeyChar.ToString()), int.Parse(selectedColumn.KeyChar.ToString()));
					}
					catch (FormatException)
					{
						moveMade = false;
					}

					Console.WriteLine();
				}

				Game.Running = !Game.CheckWinner(ActualPlayer);

				if (Game.Running)
				{
					Game.Running = !Game.CheckHash();
					ActualPlayer = null!;
				}
			}
		}

		public static void EndingGame()
		{

			Console.Clear();
			Console.Write($"\n{Game}\n");

			if (ActualPlayer != null)
			{
				Console.WriteLine($"GAME RESULT: {ActualPlayer.Symbol} WON THE GAME");
				ActualPlayer.Score++;
			}
			else
			{
				Console.WriteLine("GAME RESULT: DRAW");
			}

			Console.WriteLine();

		}

		public static string ShowScore(bool final = false) // Parece que eu consigo adicionar um valor padrão para o argumento
		{
			return $"\n{((final) ? "FINAL " : "")}SCORE:" +
				$"\nPlayer 1({Game.Players[0].Symbol}): {Game.Players[0].Score}" +
				$"\nPlayer 2({Game.Players[1].Symbol}): {Game.Players[1].Score}{((!final) ? "\n" : "")}";
		}

	}
}