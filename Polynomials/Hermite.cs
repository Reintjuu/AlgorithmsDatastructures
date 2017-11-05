using System;

namespace ADCode.Polynomials
{
	public class Hermite
	{
		public float HermiteRecursive(float x, int i)
		{
			float hZero = 1f;
			float hOne = x;
			float hTwo = x * x - 1;

			if (i < 0)
			{
				throw new ArgumentException("i can't be lower than 0.");
			}
			
			switch (i)
			{
				case 0:
					return hZero;
				case 1:
					return hOne;
			}
			
			// while ()
			
			throw new NotImplementedException();
		}
	}
}