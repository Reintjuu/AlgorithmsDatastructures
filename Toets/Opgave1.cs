using System;

namespace ADCode.Toets
{
	public class Opgave1
	{
		public Opgave1()
		{
			Console.WriteLine(PrintLetters(3));
			Console.WriteLine(PrintLetters(3, 5));
			Console.WriteLine(PrintLetters(2, 0));
		}

		private string PrintLetters(int n)
		{
			if (n <= 0)
			{
				return String.Empty;
			}

			return "A" + PrintLetters(n - 1) + "Z";
		}

		private string PrintLetters(int p, int q)
		{
			if (p <= 0 && q <= 0)
			{
				return string.Empty;
			}

			string s = string.Empty;
			if (p > 0)
			{
				s += "A";
			}

			s += PrintLetters(p - 1, q - 1);
			
			if (q > 0)
			{
				s += "Z";
			}

			return s;
		}
	}
}