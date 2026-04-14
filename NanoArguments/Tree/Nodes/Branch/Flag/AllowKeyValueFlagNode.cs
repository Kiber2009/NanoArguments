using System;
using System.Collections.Generic;

namespace NanoArguments.Tree.Nodes.Branch.Flag;

public class AllowKeyValueFlagNode(IDictionary<string, ISet<string>?>? arguments) : BranchNode
{
    public override Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        context.AllowKeyValueArguments(arguments);
        return base.Parse(context, pos);
    }
}