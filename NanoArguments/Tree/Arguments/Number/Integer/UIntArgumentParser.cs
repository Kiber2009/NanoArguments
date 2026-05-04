namespace NanoArguments.Tree.Arguments.Number.Integer;

public class UIntArgumentParser : IArgumentParser<uint>
{
    public static UIntArgumentParser Instance { get; } = new();
    private UIntArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return uint.TryParse(value, out _);
    }

    public uint Parse(ParsingContext context, string value)
    {
        return uint.Parse(value);
    }
}