namespace NanoArguments.Tree.Arguments.Number.Floating;

public class DoubleArgumentParser : IArgumentParser<double>
{
    public static DoubleArgumentParser Instance { get; } = new();
    private DoubleArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        return double.TryParse(value, out _);
    }

    public double Parse(ParsingContext context, string value)
    {
        return double.Parse(value);
    }
}