using System.Text;

namespace JsonStringFormatter.Implementation;
internal static class FormateJsonStringImpl
{
    public static string? Impl(string? str)
    {
        if (str == null)
        {
            return null;
        }

        str = str.Replace(Environment.NewLine, "").Replace("\t", "");
        Stack<char> stack = new();
        var sb = new StringBuilder();
        bool isInQuote = false;

        foreach (var c in str)
        {

            if (c == '{' || c == '[')
            {
                stack.Push(c);
                sb = sb.Append(c).AddNewLine().AddTab(stack.Count);
            }
            else if (c == '}' || c == ']')
            {
                stack.Pop();
                sb = sb.AddNewLine().AddTab(stack.Count).Append(c);
            }

            else if (c == ',' && !isInQuote)
            {
                if (sb.ToString()[sb.Length - 1] == '}' || sb.ToString()[sb.Length - 1] == ']')
                {
                    sb = sb.Append(c).AddNewLine().AddTab(stack.Count);
                }
                else
                {
                    sb = sb.Append(c).AddNewLine().AddTab(stack.Count);
                }


            }
            else if (c == '"')
            {
                isInQuote = !isInQuote;
                if (sb.ToString()[sb.Length - 1] == '}' || sb.ToString()[sb.Length - 1] == ']' || sb.ToString()[sb.Length - 1] == ',')
                {
                    sb = sb.AddNewLine().AddTab(stack.Count).Append(c);
                }
                else sb = sb.Append(c);

            }
            else
            {
                sb = sb.Append(c);
            }
        }

        return sb.ToString();

    }

    private static StringBuilder AddNewLine(this StringBuilder str)
    {
        return str.Append(Environment.NewLine);
    }

    private static StringBuilder AddTab(this StringBuilder str, int count)
    {
        while (count > 0)
        {
            str = str.Append('\t');
            count--;
        };
        return str;
    }

}
