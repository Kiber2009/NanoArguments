using System.Collections.Generic;
using System.Linq;
using NanoArguments.ArgumentTokens;

namespace NanoArguments;

public static class SimpleParser
{
    public static IEnumerable<IArgumentToken> ParseArgumentToken(string arg)
    {
        if (!arg.StartsWith('-'))
            return [new SimpleArgumentToken(arg)];

        string tmp = arg[1..];
        if (!tmp.StartsWith('-'))
            return tmp.Select(c => new FlagArgumentToken(c));

        tmp = tmp[1..];
        string[] parts = tmp.Split('=', 2);
        if (parts.Length < 2)
        {
            return [new LongFlagArgumentToken(tmp)];
        }

        return [new KeyValueFlagArgumentToken(parts[0], parts[1])];
    }

    public static IArgumentToken[] ParseArgumentTokens(IEnumerable<string> args)
    {
        List<IArgumentToken> result = [];
        foreach (string arg in args)
            result.AddRange(ParseArgumentToken(arg));
        return result.ToArray();
    }
}