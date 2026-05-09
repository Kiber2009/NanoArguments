using System;
using System.Collections.Frozen;
using System.Collections.Generic;

namespace NanoArguments.Tree.Nodes.Branch;

public class LiteralNode(ISet<string> literal) : BranchNode
{
    public LiteralNode(params string[] literal) : this(literal.ToFrozenSet()) { }

    public override bool Check(ParsingContext context, uint pos)
    {
        return literal.Contains(context.ParserResult.PositionalArgs[pos]);
    }

    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        return base.Parse(context, pos + 1);
    }
}