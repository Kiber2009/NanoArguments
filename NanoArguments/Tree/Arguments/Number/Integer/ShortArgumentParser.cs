namespace NanoArguments.Tree.Arguments.Number.Integer;

public class ShortArgumentParser : IArgumentParser<short>
{
    public static ShortArgumentParser Instance { get; } = new();
    private ShortArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return short.TryParse(value, out _);
    }

    public short Parse(ParsingContext context, string value)
    {
        return short.Parse(value);
    }
}