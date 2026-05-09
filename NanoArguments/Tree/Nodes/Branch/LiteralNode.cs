using System;
using System.Collections.Generic;

namespace NanoArguments.Tree.Nodes.Branch;

public class LiteralNode(ISet<string> literal) : BranchNode
{
    public LiteralNode(string literal) : this(new HashSet<string> { literal }) { }

    public override bool Check(ParsingContext context, uint pos)
    {
        return literal.Contains(context.ParserResult.PositionalArgs[pos]);
    }

    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        return base.Parse(context, pos + 1);
    }
}