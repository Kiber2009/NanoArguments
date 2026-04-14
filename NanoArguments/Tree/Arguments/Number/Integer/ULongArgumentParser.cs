namespace NanoArguments.Tree.Arguments.Number.Integer;

public class ULongArgumentParser : IArgumentParser<ulong>
{
    public bool Check(ParsingContext context, string value)
    {
        return ulong.TryParse(value, out _);
    }

    public ulong Parse(ParsingContext context, string value)
    {
        return ulong.Parse(value);
    }
}