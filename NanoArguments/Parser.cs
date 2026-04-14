using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using NanoArguments.ArgumentTokens;
using NanoArguments.Exceptions;
using NanoArguments.Tree;
using NanoArguments.Tree.Nodes;

namespace NanoArguments;

public class Parser(
    INode baseNode,
    ISet<char>? allowedFlags = null,
    ISet<string>? allowedLongFlags = null,
    IDictionary<string, ISet<string>?>? allowedKeyValueArguments = null,
    ISet<string>? boolTrueValues = null,
    ISet<string>? boolFalseValues = null,
    bool boolValuesCompareLowercase = false
)
{
    public void Parse(IEnumerable<string> args)
    {
        Parse(SimpleParserResult.Parse(args));
    }

    public void Parse(IEnumerable<IArgumentToken> args)
    {
        Parse(SimpleParserResult.Parse(args));
    }

    public void Parse(SimpleParserResult result)
    {
        ParsingContext context = new(result,
            (boolTrueValues ?? new HashSet<string> { "true" }).ToFrozenSet(),
            (boolFalseValues ?? new HashSet<string> { "false" }).ToFrozenSet(),
            boolValuesCompareLowercase);
        context.AllowFlags(allowedFlags);
        context.AllowLongFlags(allowedLongFlags);
        context.AllowKeyValueArguments(allowedKeyValueArguments);

        if (!baseNode.Check(context, 0))
            throw new CommandSyntaxException("Base node unable to parse command");

        Action<ParsingContext> action = baseNode.Parse(context, 0);

        context.CheckFlags();

        action(context);
    }
}