namespace NanoArguments.Tree.Arguments;

public class StringArgumentParser : IArgumentParser<string>
{
    public static StringArgumentParser Instance { get; } = new();
    private StringArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return true;
    }

    public string Parse(ParsingContext context, string value)
    {
        return value;
    }
}