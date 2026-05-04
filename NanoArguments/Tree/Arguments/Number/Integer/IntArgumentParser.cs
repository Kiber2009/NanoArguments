namespace NanoArguments.Tree.Arguments.Number.Integer;

public class IntArgumentParser : IArgumentParser<int>
{
    public static IntArgumentParser Instance { get; } = new();
    private IntArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return int.TryParse(value, out _);
    }

    public int Parse(ParsingContext context, string value)
    {
        return int.Parse(value);
    }
}