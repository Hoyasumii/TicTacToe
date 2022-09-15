using System;
using System.Text;

namespace TicTacToe.Entities
{
	public class Game
	{
		public bool Running { get; set; }
		private string[,] Board { get; set; } = null!;

		private int _actualPlayer = 1;

		public int ActualPlayer
		{
			get
			{
				_actualPlayer = (_actualPlayer == 0) ? 1 : 0;
				return _actualPlayer;
			}
		}

		public Player[] Players { get; private set; } = new Player[2];

		public Game(Player player1, Player player2)
		{
			Players[0] = player1;
			Players[1] = player2;
		}

		public void StartGame()
		{
			_actualPlayer = 1;
			Board = new string[3, 3];
			Running = true;
		}

		public bool Move(Player selectedPlayer, int selectedLine, int selectedColumn)
		{
			selectedLine--;
			selectedColumn--;

			selectedLine = (selectedLine >= 0 && selectedLine <= 2) ? selectedLine : 0;
			selectedColumn = (selectedColumn >= 0 && selectedColumn <= 2) ? selectedColumn : 0;

			if (Board[selectedLine, selectedColumn] == null)
			{
				Board[selectedLine, selectedColumn] = selectedPlayer.Symbol;
				return true;
			}

			else return false;
		}

		public override string ToString()
		{
			StringBuilder displayBoard = new();

			displayBoard.AppendLine("  1 2 3");

			for (int line = 0; line < Board.GetLength(0); line++)
			{

				displayBoard.Append($"{line + 1} ");

				for (int column = 0; column < Board.GetLength(1); column++)
				{
					displayBoard.Append($"{Board[line, column] ?? " "} ");
				}

				displayBoard.AppendLine();

			}

			return displayBoard.ToString();
		}

		public bool CheckWinner(Player selectedPlayer)
		{

			for (int line = 0; line < Board.GetLength(0); line++)
			{
				if (Board[line, 0] == selectedPlayer.Symbol && (Board[line, 0] == Board[line, 1]) && (Board[line, 1] == Board[line, 2]))
				{
					return true;
				}
			}

			for (int column = 0; column < Board.GetLength(0); column++)
			{
				if (Board[0, column] == selectedPlayer.Symbol && (Board[0, column] == Board[1, column]) && (Board[1, column] == Board[2, column]))
				{
					return true;
				}
			}

			if (Board[0, 0] == selectedPlayer.Symbol && (Board[0, 0] == Board[1, 1]) && (Board[1, 1] == Board[2, 2]))
			{
				return true;
			}

			if (Board[0, 2] == selectedPlayer.Symbol && (Board[0, 2] == Board[1, 1]) && (Board[1, 1] == Board[2, 0]))
			{
				return true;
			}

			return false;
		}

		public bool CheckHash()
		{
			int occupiedSpaces = 0;

			for (int line = 0; line < Board.GetLength(0); line++)
			{
				for (int column = 0; column < Board.GetLength(1); column++)
				{
					if (Board[line, column] != null!) occupiedSpaces++;
				}
			}

			if (occupiedSpaces == Board.Length) return true;
			else return false;
		}

	}
}
