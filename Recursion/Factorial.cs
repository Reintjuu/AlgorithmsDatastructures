namespace ADCode.Recursion
{
	public static class Factorial
	{
		// Week 3 - Opdracht 1
		public static uint RecursiveFactorial(uint value)
		{
			if (value == 0)
			{
				return 1;
			}

			return value * RecursiveFactorial(value - 1);
		}
	}
}