namespace ADCode.Recursion
{
	public class Factorial
	{
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