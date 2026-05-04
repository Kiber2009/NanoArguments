namespace NanoArguments.Tree.Arguments.Number.Integer;

public class ULongArgumentParser : IArgumentParser<ulong>
{
    public static ULongArgumentParser Instance { get; } = new();
    private ULongArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return ulong.TryParse(value, out _);
    }

    public ulong Parse(ParsingContext context, string value)
    {
        return ulong.Parse(value);
    }
}