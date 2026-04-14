using System.Collections.Frozen;
using System.Linq;
using NanoArguments.ArgumentTokens;

namespace NanoArguments.Tree.Conditions.Flag;

public class FlagCondition(FrozenSet<char> flags) : ICondition
{
    private readonly FrozenSet<char> _flags = flags;

    public FlagCondition(params FlagArgumentToken[] tokens) :
        this(tokens.Select(t => t.Value).ToFrozenSet()) { }

    public bool Check(SimpleParserResult result)
    {
        return _flags.All(flag => result.Flags.Contains(flag));
    }

    public static FlagCondition operator &(FlagCondition left, FlagCondition right)
    {
        return new(left._flags.Intersect(right._flags).ToFrozenSet());
    }

    public static FlagCondition operator |(FlagCondition left, FlagCondition right)
    {
        return new(left._flags.Concat(right._flags).ToFrozenSet());
    }
}