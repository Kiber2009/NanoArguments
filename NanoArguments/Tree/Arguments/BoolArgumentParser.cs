using NanoArguments.Exceptions;

namespace NanoArguments.Tree.Arguments;

public class BoolArgumentParser : IArgumentParser<bool>
{
    public static BoolArgumentParser Instance { get; } = new();
    private BoolArgumentParser() { }

    public bool Check(ParsingContext context, string value)
    {
        if (context.BoolValuesCompareLowercase)
            value = value.ToLower();

        return context.BoolTrueValues.Contains(value) || context.BoolFalseValues.Contains(value);
    }

    public bool Parse(ParsingContext context, string value)
    {
        if (context.BoolValuesCompareLowercase)
            value = value.ToLower();

        if (context.BoolTrueValues.Contains(value))
            return true;

        return context.BoolFalseValues.Contains(value)
            ? false
            : throw new CommandSyntaxException("Invalid boolean value");
    }
}