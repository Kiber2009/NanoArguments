namespace NanoArguments.Tree.Arguments;

public interface IArgumentParser<out T>
{
    public bool Check(ParsingContext context, string value);

    public T Parse(ParsingContext context, string value);
}