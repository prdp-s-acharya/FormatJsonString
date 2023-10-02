using System.Text;

namespace JsonStringFormatter
{
    public static class JsonFormater
    {
        public static string? FormatJsonString(this string? str)
        {

            if (str == null)
            {
                return null;
            }

            str = str.Replace("\r\n", "").Replace("\t", "");
            Stack<char> stack = new();
            var sb = new StringBuilder();

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

                else if (c == ',')
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
}