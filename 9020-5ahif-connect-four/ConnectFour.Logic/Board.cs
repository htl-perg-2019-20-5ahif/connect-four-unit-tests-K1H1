using System;

namespace ConnectFour.Logic
{
	public class Board
	{
		/// <summary>
		/// [Column, Row]
		/// </summary>
		private readonly byte[,] GameBoard = new byte[7, 6];

		internal int Player = 1;

		public void AddStone(byte column)
		{
			// stone is outside the board
			if (column > 6 || column < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(column));
			}

			// set stone inside the board
			for (int row = 0; row < 6; row++)
			{
				var cell = GameBoard[column, row];

				if (cell == 0)
				{
					GameBoard[column, row] = (byte)this.Player;
					if (Player == 1)
					{
						Player = 2;
					}
					else
					{
						Player = 1;
					}
					return;
				}
			}

			throw new InvalidOperationException("Column is full");
		}
		public int GetOldPlayer()
		{
			if (Player == 1)
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}
		public bool CheckIfPlayerHasWon()
		{
			// horizontalCheck 
			for (int j = 0; j < 6 - 3; j++)
			{
				for (int i = 0; i < 7; i++)
				{
					if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i, j + 1] == this.GetOldPlayer() && this.GameBoard[i, j + 2] == this.GetOldPlayer() && this.GameBoard[i, j + 3] == this.GetOldPlayer())
					{
						return true;
					}
				}
			}
			// verticalCheck
			for (int i = 0; i < 7 - 3; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i + 1, j] == this.GetOldPlayer() && this.GameBoard[i + 2, j] == this.GetOldPlayer() && this.GameBoard[i + 3, j] == this.GetOldPlayer())
					{
						return true;
					}
				}
			}
			// ascendingDiagonalCheck 
			for (int i = 3; i < 7; i++)
			{
				for (int j = 0; j < 6 - 3; j++)
				{
					if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i - 1, j + 1] == this.GetOldPlayer() && this.GameBoard[i - 2, j + 2] == this.GetOldPlayer() && this.GameBoard[i - 3, j + 3] == this.GetOldPlayer())
						return true;
				}
			}
			// descendingDiagonalCheck
			for (int i = 3; i < 7; i++)
			{
				for (int j = 3; j < 6; j++)
				{
					if (this.GameBoard[i, j] == this.GetOldPlayer() && this.GameBoard[i - 1, j - 1] == this.GetOldPlayer() && this.GameBoard[i - 2, j - 2] == this.GetOldPlayer() && this.GameBoard[i - 3, j - 3] == this.GetOldPlayer())
						return true;
				}
			}
			return false;
		}
		public byte[,] GetBoard()
		{
			return this.GameBoard;
		}

		public bool CheckIfBoardIsFull()
		{
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (this.GameBoard[i, j] == 0)
						return false;
				}
			}
			return true;
		}
	}
}
