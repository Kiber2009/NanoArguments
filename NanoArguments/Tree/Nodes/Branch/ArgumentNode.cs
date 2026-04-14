using System;
using NanoArguments.Tree.Arguments;

namespace NanoArguments.Tree.Nodes.Branch;

public class ArgumentNode<T>(IArgumentParser<T> parser, string name) : BranchNode
{
    public bool Check(ParsingContext context, uint pos)
    {
        return parser.Check(context, context.ParserResult.PositionalArgs[pos]);
    }

    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        T res = parser.Parse(context, context.ParserResult.PositionalArgs[pos]);
        context.AddArgument(name, res);
        return base.Parse(context, pos + 1);
    }
}