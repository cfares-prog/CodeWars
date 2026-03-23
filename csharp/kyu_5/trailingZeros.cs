namespace TrailingZeros;

public static class Kata
{
    public static int TrailingZeros(int n)
    {
        int count = 0;
        while(n >= 5)
        {
            n /= 5;
            count++;
        }
        return count;
    }

    public static int LinqTrailingZeros(int n)
    {
        return Enumerable.Range(1, (int)Math.Log(n, 5)).Sum(i => (int) (n / Math.Pow(5, i)));
    }
}
