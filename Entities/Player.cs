using System;

namespace TicTacToe.Entities
{
	public class Player
	{
		public string Name { get; private set; }
		public string Symbol { get; private set; }
		public int Score { get; set; }

		public Player(string name, string symbol)
		{
			Name = name;
			Symbol = symbol;
			Score = 0;
		}

	}
}
