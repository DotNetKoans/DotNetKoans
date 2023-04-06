using Xunit;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutBitwiseAndShiftOperator : Koan
{
	[Step(1)]
	public void BinaryAndOperator()
	{
		//Example
		//1 in binary is 0001
		//3 in binary is 0011
		//With & only taking the same one else take 0,so 1 & 3 it becomes 0001.
		//When 0001 convert to int it becomes 1
		int x = 4 & 4;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(2)]
	public void BinaryOrOperator()
	{
		//Example
		//1 in binary is 0001
		//3 in binary is 0011
		//With | it will take any 1 if either one contains 1,so 1 & 3 it becomes 0011.
		//When 0011 convert to int it becomes 3
		int x = 4 | 4;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(3)]
	public void BinaryXOrOperator()
	{
		//Example
		//1 in binary is 0001
		//3 in binary is 0011
		//With ^ it will take 1 when it is 0-1, if it is 1-1 it will take 0,so 1 & 3 it becomes 0010.
		//When 0010 convert to int it becomes 2
		int x = 4 ^ 4;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(4)]
	public void BinaryOnesComplementOperator()
	{
		//Example
		//With ~ it will convert positive number to negative number and add -1 to the number.
		// ~1 become -2
		int x = ~4;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(5)]
	public void Combination1()
	{
		int x = ~3 & 8;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(6)]
	public void Combination2()
	{
		int x = 4 | 4 & 8;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(7)]
	public void Combination3()
	{
		int x = 3 & 4 ^ 4 & ~8;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(8)]
	public void BitwiseLeftShift()
	{
		//Example
		//4 in binary is 0100
		//when we try to 4 << 1
		//it becomes 1000
		//then it will become 8
		int x = 10 << 2;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(9)]
	public void BitwiseRightShift()
	{
		//Example
		//4 in binary is 0100
		//when we try to 4 >> 1
		//it becomes 0010
		//then it will become 2
		int x = 12 >> 2;
		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(10)]
	public void Combination4()
	{
		int x = (5 << 2) & 8 ^ 3;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(11)]
	public void Combination5()
	{
		int x = (5 >> 2) & (~8) ^ 8;

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(12)]
	public void Combination6()
	{
		int x = (8 << 2) & (~5) & 8 | 10 | (5 >> 1);

		Assert.Equal(FILL_ME_IN, x);
	}

	[Step(13)]
	public void AdditionWithoutPlusOrMinusOperator()
	{
		//Solve this problem without using + or -
		//This is a complicated problem. If you don't 
		//know how to solve it, try to Google it.
		int a = 15;
		int b = 4;

		//Here goes your implementation to set value to FILL_ME_IN
		Assert.Equal(FILL_ME_IN, 19);
	}
}