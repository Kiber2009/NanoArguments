using System;
using System.Collections.Frozen;

namespace NanoArguments.Tree.Nodes.Branch.Flag;

public class AllowFlagNode(params char[]? flags) : BranchNode
{
    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        context.AllowFlags(flags?.ToFrozenSet());
        return base.Parse(context, pos);
    }
}