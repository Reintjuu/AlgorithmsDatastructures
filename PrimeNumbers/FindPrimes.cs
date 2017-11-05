using System;

namespace ADCode.PrimeNumbers
{
	public class FindPrimes
	{
		// Week 1 - Opgave 1
		public bool[] SieveOfEratosthenes(uint n)
		{
			if (!(n > 1))
			{
				throw new ArgumentException("n should be bigger than 1");
			}

			bool[] isPrime = new bool[n + 1];
			for (int i = 2; i <= n; i++)
			{
				isPrime[i] = true;
			}
			
			for (int i = 2; i <= n; i++)
			{
				if (isPrime[i])
				{
					for (int j = i * 2; j <= n; j += i)
					{
						isPrime[j] = false;
					}
				}
			}

			return isPrime;
		}
	}
}