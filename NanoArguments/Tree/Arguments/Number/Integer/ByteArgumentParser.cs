namespace NanoArguments.Tree.Arguments.Number.Integer;

public class ByteArgumentParser : IArgumentParser<byte>
{
    public static ByteArgumentParser Instance { get; } = new();
    private ByteArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return byte.TryParse(value, out _);
    }

    public byte Parse(ParsingContext context, string value)
    {
        return byte.Parse(value);
    }
}