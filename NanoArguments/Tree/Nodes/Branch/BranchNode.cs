using System;
using System.Collections.Generic;
using NanoArguments.Exceptions;
using NanoArguments.Tree.Conditions;

namespace NanoArguments.Tree.Nodes.Branch;

public class BranchNode : INode
{
    private readonly List<(INode node, ICondition? condition)> _branches = [];

    public BranchNode Then(INode branch)
    {
        return ThenIf(null, branch);
    }

    public BranchNode ThenIf(ICondition? condition, INode branch)
    {
        _branches.Add((branch, condition));
        return this;
    }

    public virtual Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        foreach ((INode node, ICondition? condition) in _branches)
        {
            if (!(condition?.Check(context.ParserResult) ?? true))
                continue;
            return node.Parse(context, pos);
        }

        throw new CommandSyntaxException("No branches matching the condition were found", pos);
    }
}