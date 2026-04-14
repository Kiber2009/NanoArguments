using System;
using System.Collections.Frozen;

namespace NanoArguments.Tree.Nodes.Branch.Flag;

public class AllowLongFlagNode(params string[]? flags) : BranchNode
{
    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        context.AllowLongFlags(flags?.ToFrozenSet());
        return base.Parse(context, pos);
    }
}