using NanoArguments.Tree.Conditions.Bool;

namespace NanoArguments.Tree.Conditions;

public interface ICondition
{
    public bool Check(SimpleParserResult result);

    static NotCondition operator !(ICondition condition)
    {
        return new(condition);
    }

    static AllCondition operator &(ICondition left, ICondition right)
    {
        return new(left, right);
    }

    static AnyCondition operator |(ICondition left, ICondition right)
    {
        return new(left, right);
    }
}