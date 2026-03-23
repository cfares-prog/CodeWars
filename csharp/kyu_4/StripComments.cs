public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {
        return string.Join("\n", text.Split("\n")
            .Select(line => line.Split(commentSymbols, StringSplitOptions.None)[0].TrimEnd()));
    }

}
