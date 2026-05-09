using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using NanoArguments.ArgumentTokens;

namespace NanoArguments.Tree.Conditions.Flag;

public class LongFlagCondition(ISet<string> flags) : ICondition
{
    private readonly ISet<string> _flags = flags;

    public LongFlagCondition(params LongFlagArgumentToken[] tokens) :
        this(tokens.Select(t => t.Value).ToFrozenSet()) { }

    public bool Check(SimpleParserResult result)
    {
        return _flags.All(flag => result.LongFlags.Contains(flag));
    }

    public static LongFlagCondition operator &(LongFlagCondition left, LongFlagCondition right)
    {
        return new(left._flags.Intersect(right._flags).ToFrozenSet());
    }

    public static LongFlagCondition operator |(LongFlagCondition left, LongFlagCondition right)
    {
        return new(left._flags.Concat(right._flags).ToFrozenSet());
    }
}