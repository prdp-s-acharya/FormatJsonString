namespace JsonStringFormatter.Implementation;

internal class PrintJsonToConsoleImpl
{
    public static void Impl(string? str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        str = str.Replace(Environment.NewLine, "").Replace("\t", "");

        var defaultColor = ConsoleColor.White;
        var keyColor = ConsoleColor.DarkYellow;
        var nullColor = ConsoleColor.DarkCyan;
        var numerColor = ConsoleColor.Red;
        var valueColor = ConsoleColor.Magenta;
        var currentColor = defaultColor;

        Stack<char> stack = new();

        bool isKey = true;
        bool isInQuote = false;
        bool isNumeric = false;
        bool isNull = false;

        int tabsize = 1;

        foreach (var c in str)
        {
            if (c == ':' && !isInQuote)
            {
                isKey = false;
                Console.ForegroundColor = defaultColor;
                Console.Write(c);
            }
            else if (c == '{' || c == '[')
            {
                stack.Push(c);

                Console.ForegroundColor = defaultColor;
                Console.WriteLine(c);
                PrintTab(tabsize, stack.Count);
            }
            else if (c == '}' || c == ']')
            {
                Console.ForegroundColor = defaultColor;
                Console.WriteLine();
                PrintTab(tabsize, stack.Count);

                stack.Pop();
                Console.Write(c);
            }

            else if (c == ',' && !isInQuote)
            {
                isKey = true;
                Console.ForegroundColor = defaultColor;
                Console.WriteLine(c);
                PrintTab(tabsize, stack.Count);

            }
            else if (c == '"')
            {
                isInQuote = !isInQuote;
                if (isKey)
                {
                    Console.ForegroundColor = keyColor;
                    Console.Write(c);
                }
                else
                {
                    Console.ForegroundColor = valueColor;
                    Console.Write(c);
                }

            }
            else
            {
                if (isKey)
                {
                    Console.ForegroundColor = keyColor;
                    Console.Write(c);
                }
                else
                {
                    Console.ForegroundColor = valueColor;
                    Console.Write(c);
                }
            }
        }
    }

    private static void PrintTab(int tabsize, int count)
    {
        int tot = tabsize * count;
        while(tot > 0)
        {
            Console.Write(" ");
            tot--;
        }
    }
}

