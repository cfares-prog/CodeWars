public class PrimeDecomp
{
    public static string factors(int lst)
    {
        string result = "";
        for(int i = 0; i < lst; i++)
        {
            int count = 0;
            if(lst % i == 0)
            {
                count++;
                lst /= i;
            }

            if(count > 0)
            {
                if(count > 1) result += $"({i}**{count})";
                else result += $"({i})";
            }
        }
        return result;
    }
}
