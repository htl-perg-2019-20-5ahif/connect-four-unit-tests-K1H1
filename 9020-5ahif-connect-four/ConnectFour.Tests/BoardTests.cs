using ConnectFour.Logic;
using System;
using Xunit;

namespace ConnectFour.Tests
{
	public class BoardTests
	{
		[Fact]
		public void AddWithInvalidColumnIndex()
		{
			var b = new Board();

			Assert.Throws<ArgumentOutOfRangeException>(() => b.AddStone(7));
		}

		[Fact]
		public void PlayerChangesWhenAddingStone()
		{
			var b = new Board();

			var oldPlayer = b.Player;
			b.AddStone(0);

			// Verify that player has changed
			Assert.NotEqual(oldPlayer, b.Player);
		}

		[Fact]
		public void AddingTooManyStonesToARow()
		{
			var b = new Board();

			for (var i = 0; i < 6; i++)
			{
				b.AddStone(0);
			}

			var oldPlayer = b.Player;
			Assert.Throws<InvalidOperationException>(() => b.AddStone(0));
			Assert.Equal(oldPlayer, b.Player);
		}

		// correct placed stones are handled appropriately
		[Fact]
		public void StoneCorrectlyPlaced()
		{
			var b = new Board();
			var oldPlayer = b.Player;

			b.AddStone(2);
			Assert.Equal(b.GetBoard()[2, 0], oldPlayer);

			oldPlayer = b.Player;
			b.AddStone(5);
			Assert.Equal(b.GetBoard()[5, 0], oldPlayer);
		}

		
		//game ends if player wins

		// horizontally
		[Fact]
		public void HorizontalWin()
		{
			var b = new Board();

			for (byte i = 0; i < 4; i++)
			{
				b.AddStone(i);
				b.AddStone(i);
			}

			Assert.True(b.CheckIfPlayerHasWon());
		}

		// vertically
		[Fact]
		public void VerticallWin()
		{
			var b = new Board();

			for (byte i = 0; i < 4; i++)
			{
				b.AddStone(1);
				b.AddStone(2);
			}

			Assert.True(b.CheckIfPlayerHasWon());
		}

		//diagonally
		[Fact]

		public void LowerLeftToUpperRightWin()
		{
			var b = new Board();
			b.AddStone(0);
			b.AddStone(2);
			b.AddStone(1);
			b.AddStone(3);
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);

			Assert.True(b.CheckIfPlayerHasWon());
		}


		[Fact]
		public void UpperLeftToLowerRightWin()
		{
			var b = new Board();
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);
			b.AddStone(4);
			b.AddStone(3);
			b.AddStone(3);
			b.AddStone(1);
			b.AddStone(2);
			b.AddStone(0);

			Assert.True(b.CheckIfPlayerHasWon());
		}

		// game ends if board is full and no player has won
		[Fact]
		public void BoardFull()
		{

			var b = new Board();
			for (byte i = 0; i < 7; i++)
			{
				for (byte j = 0; j < 6; j++)
				{
					b.AddStone(i);

				}
			}

			Assert.True(b.CheckIfBoardIsFull());
		}

		[Fact]
		public void BoardNotFull()
		{

			var b = new Board();
		
			b.AddStone(1);
s
			Assert.False(b.CheckIfBoardIsFull());
		}

	}
}

