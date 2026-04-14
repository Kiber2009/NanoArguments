namespace NanoArguments.Tree.Arguments.Number.Floating;

public class DecimalArgumentParser : IArgumentParser<decimal>
{
    public bool Check(ParsingContext context, string value)
    {
        return decimal.TryParse(value, out _);
    }

    public decimal Parse(ParsingContext context, string value)
    {
        return decimal.Parse(value);
    }
}