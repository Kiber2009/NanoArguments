using System;

namespace NanoArguments.Tree.Nodes;

public interface INode
{
    public bool Check(ParsingContext context, uint pos);

    public Action<ParsingContext> Parse(ParsingContext context, uint pos);
}