using System;

namespace NanoArguments.Tree.Nodes.Branch;

public class LiteralNode(string literal) : BranchNode
{
    public bool Check(ParsingContext context, uint pos)
    {
        return context.ParserResult.PositionalArgs[pos] == literal;
    }

    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        return base.Parse(context, pos + 1);
    }
}