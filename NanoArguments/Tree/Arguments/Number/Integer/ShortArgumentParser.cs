namespace NanoArguments.Tree.Arguments.Number.Integer;

public class ShortArgumentParser : IArgumentParser<short>
{
    public bool Check(ParsingContext context, string value)
    {
        return short.TryParse(value, out _);
    }

    public short Parse(ParsingContext context, string value)
    {
        return short.Parse(value);
    }
}