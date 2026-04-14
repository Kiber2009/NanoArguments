namespace NanoArguments.Tree.Conditions;

public class BoolCondition(bool value) : ICondition
{
    private readonly bool _value = value;

    public bool Check(SimpleParserResult result)
    {
        return _value;
    }

    public static BoolCondition operator !(BoolCondition condition)
    {
        return new(!condition._value);
    }

    public static ICondition operator &(BoolCondition left, ICondition right)
    {
        return left._value ? right : left;
    }

    public static ICondition operator &(ICondition left, BoolCondition right)
    {
        return right._value ? left : right;
    }

    public static ICondition operator |(BoolCondition left, ICondition right)
    {
        return left._value ? left : right;
    }

    public static ICondition operator |(ICondition left, BoolCondition right)
    {
        return right._value ? right : left;
    }
}