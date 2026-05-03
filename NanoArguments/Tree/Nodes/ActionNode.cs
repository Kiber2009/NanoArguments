using System;

namespace NanoArguments.Tree.Nodes;

public class ActionNode(Action<ParsingContext> action) : INode
{
    public bool Check(ParsingContext context, uint pos)
    {
        return true;
    }

    public Action<ParsingContext> Parse(ParsingContext context, uint pos)
    {
        return action;
    }
}