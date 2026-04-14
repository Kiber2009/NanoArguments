namespace NanoArguments.Tree.Arguments.Number.Integer;

public class LongArgumentParser : IArgumentParser<long>
{
    public bool Check(ParsingContext context, string value)
    {
        return long.TryParse(value, out _);
    }

    public long Parse(ParsingContext context, string value)
    {
        return long.Parse(value);
    }
}