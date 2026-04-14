using System.Linq;

namespace NanoArguments.Tree.Conditions.Bool;

public class AnyCondition(params ICondition[] conditions) : ICondition
{
    private readonly ICondition[] _conditions = conditions;

    public bool Check(SimpleParserResult result)
    {
        return _conditions.Any(condition => condition.Check(result));
    }
    
    public static AnyCondition operator |(AnyCondition left, ICondition right)
    {
        return new(left._conditions.Append(right).ToArray());
    }

    public static AnyCondition operator |(ICondition left, AnyCondition right)
    {
        return new(right._conditions.Append(left).ToArray());
    }

    public static AnyCondition operator |(AnyCondition left, AnyCondition right)
    {
        return new(left._conditions.Concat(right._conditions).ToArray());
    }
}