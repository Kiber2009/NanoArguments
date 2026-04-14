using System.Collections.Frozen;
using System.Collections.Generic;
using NanoArguments.ArgumentTokens;

namespace NanoArguments;

public record SimpleParserResult(
    string[] PositionalArgs,
    FrozenSet<char> Flags,
    FrozenSet<string> LongFlags,
    FrozenDictionary<string, string> KeyValueFlags)
{
    public static SimpleParserResult Parse(IEnumerable<IArgumentToken> args)
    {
        List<string> positional = [];
        HashSet<char> flags = [];
        HashSet<string> longFlags = [];
        Dictionary<string, string> keyValues = [];
        foreach (IArgumentToken arg in args)
            switch (arg)
            {
                case SimpleArgumentToken simple:
                    positional.Add(simple.Value);
                    break;
                case FlagArgumentToken flag:
                    flags.Add(flag.Value);
                    break;
                case LongFlagArgumentToken longFlag:
                    longFlags.Add(longFlag.Value);
                    break;
                case KeyValueFlagArgumentToken keyValue:
                    keyValues.Add(keyValue.Key, keyValue.Value);
                    break;
            }

        return new(positional.ToArray(), flags.ToFrozenSet(), longFlags.ToFrozenSet(), keyValues.ToFrozenDictionary());
    }

    public static SimpleParserResult Parse(IEnumerable<string> args)
    {
        return Parse(SimpleParser.ParseArgumentTokens(args));
    }
};