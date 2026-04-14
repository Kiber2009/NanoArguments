using System.Linq;

namespace NanoArguments.Tree.Conditions.Bool;

public class AllCondition(params ICondition[] conditions) : ICondition
{
    private readonly ICondition[] _conditions = conditions;

    public bool Check(SimpleParserResult result)
    {
        return _conditions.All(condition => condition.Check(result));
    }

    public static AllCondition operator &(AllCondition left, ICondition right)
    {
        return new(left._conditions.Append(right).ToArray());
    }

    public static AllCondition operator &(ICondition left, AllCondition right)
    {
        return new(right._conditions.Append(left).ToArray());
    }

    public static AllCondition operator &(AllCondition left, AllCondition right)
    {
        return new(left._conditions.Concat(right._conditions).ToArray());
    }
}