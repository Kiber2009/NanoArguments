using System;

namespace NanoArguments.Tree.Nodes;

public interface INode
{
    bool Check(ParsingContext context, uint pos)
    {
        return true;
    }

    Action<ParsingContext> Parse(ParsingContext context, uint pos);
}