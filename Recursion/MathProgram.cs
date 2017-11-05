using System;
using System.Diagnostics;

namespace ADCode.Recursion
{
	public class MathProgram
	{
		public MathProgram()
		{
			// Console.WriteLine(Math.Sum(123));
			Console.WriteLine(Math.BinaryOnes(2345));
			// PowBenchmark();
		}

		private void PowBenchmark()
		{
			Stopwatch s = new Stopwatch();
			uint n = 50000;

			Console.WriteLine("Init.");
			s.Start();
			for (uint i = 0; i < 1000000; i++)
			{
				Math.Pow(3, n);
				System.Math.Pow(3, n);
			}
			s.Stop();

			for (int index = 0; index < 10; index++)
			{
				Console.WriteLine("Smart pow.");
				s.Restart();
				for (uint i = 0; i < 1000000; i++)
				{
					Math.Pow(3, n);
				}
				s.Stop();

				Console.WriteLine($"{index}	{s.Elapsed}");
				
				Console.WriteLine("System pow.");
				s.Restart();
				for (uint i = 0; i < 1000000; i++)
				{
					System.Math.Pow(3, n);
				}
				s.Stop();

				Console.WriteLine($"{index}	{s.Elapsed}");

				n *= n;
			}
		}
	}
}