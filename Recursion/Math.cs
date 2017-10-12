namespace ADCode.Recursion
{
	public class Math
	{
		public static int Sum(int n)
		{
			if (n <= 0)
			{
				return 0;
			}

			return n % 10 + Sum(n / 10);
		}

		// Smart pow with divide and conquer.
		public static double Pow(double x, uint y)
		{
			// Power of 0 is always 1.
			if (y == 0)
			{
				return 1;
			}
			
			// If an even number.
			if (y % 2 == 0)
			{
				// Integer division the two numbers.
				double temp = Pow(x, y / 2);
				return temp * temp;
			}
			
			// If uneven, try again with an even number. And multiply by the recursive answer.
			return x * Pow(x, y - 1);
		}
	}
}