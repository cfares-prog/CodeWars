using System.Collections.Generic;

public static class moleculeToAtomsSolutoin
{
    public static Dictionary<string, int> ParseMolecule(string formula)
    {
        var stack = new Stack<Dictionary<string, int>> ();
        stack.Push(new Dictionary<string, int> ());
        for(int i = 0; i < formula.Length; )
        {
            char c = formula[i];
            if(c == '(' || c == '[')
            {
                stack.Push(new Dictionary<string, int> ());
                i++;
            }
            else if(c == ')' || c == ']')
            {
                var top = stack.Pop();
                i++;
                int multiplier = ParseNumber(formula, ref i);
                
                foreach(var kv in top)
                {
                    if(!stack.Peek().ContainsKey(kv.Key)) stack.Peek()[kv.Key] = 0;
                    stack.Peek()[kv.Key] += kv.Value * multiplier;
                }
            }
            else if(char.IsUpper(c))
            {
                string element = c.ToString();
                i++;

                while(i < formula.Length && char.IsLower(formula[i])) element += formula[i++];

                int count = ParseNumber(formula, ref i);
                if(!stack.Peek().ContainsKey(element)) stack.Peek()[element] = 0;
                stack.Peek()[element] += count;
            }
            else i++;
        }
        return stack.Pop();
    }

    //helper method to detect full numbers
    public static int ParseNumber(string formula, ref int i)
    {
        int start = i;

        while(i < formula.Length && char.IsDigit(formula[i]))
        {
            i++;
        }

        if(start == i) return 1;

        return int.Parse(formula.Substring(start, i - start));
    }

}

public class Test
{
    public static void Main()
    {
        var result = moleculeToAtomsSolutoin.ParseMolecule("K4[ON(SO3)2]2");

        foreach(var kv in result)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        }
    }
}
