namespace NanoArguments.Tree.Arguments;

public interface IArgumentParser<out T>
{
    bool Check(ParsingContext context, string value);

    T Parse(ParsingContext context, string value);
}