namespace ADCode.Recursion
{
	public static class Math
	{
		public static int Sum(int n)
		{
			if (n <= 0)
			{
				return 0;
			}

			return n % 10 + Sum(n / 10);
		}

		// Week 3 - Opdracht 3
		public static int SumOmAndOm(int n)
		{
			if (n <= 0)
			{
				return 0;
			}

			return n + SumOmAndOm(n - 2);
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

		// Week 3 - Opdracht 2a
		public static int RecursiveFibonacci(int number)
		{
			if (number == 0)
			{
				return 0;
			}

			if (number == 1)
			{
				return 1;
			}
			
			return RecursiveFibonacci(number - 2) + RecursiveFibonacci(number - 1);
		}
		
		// Week 3 - Opdracht 2b
		public static long Fibonacci(int number)
		{
			long a = 1, b = 0;

			while (number >= 0)
			{
				long temp = a;
				a = a + b;
				b = temp;
				number--;
			}

			return b;
		}

		public static int BinaryOnes(int n)
		{
			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			return BinaryOnes(n / 2) + BinaryOnes(n % 2);
		}
	}
}