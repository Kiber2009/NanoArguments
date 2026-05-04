namespace NanoArguments.Tree.Arguments.Number.Floating;

public class FloatArgumentParser : IArgumentParser<float>
{
    public static FloatArgumentParser Instance { get; } = new();
    private FloatArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return float.TryParse(value, out _);
    }

    public float Parse(ParsingContext context, string value)
    {
        return float.Parse(value);
    }
}