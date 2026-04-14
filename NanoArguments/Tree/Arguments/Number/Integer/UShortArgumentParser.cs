namespace NanoArguments.Tree.Arguments.Number.Integer;

public class UShortArgumentParser : IArgumentParser<ushort>
{
    public bool Check(ParsingContext context, string value)
    {
        return ushort.TryParse(value, out _);
    }

    public ushort Parse(ParsingContext context, string value)
    {
        return ushort.Parse(value);
    }
}