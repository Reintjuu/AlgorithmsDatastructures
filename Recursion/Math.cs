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
    }
}