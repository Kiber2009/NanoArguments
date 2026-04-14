namespace NanoArguments.Tree.Conditions.Bool;

public class NotCondition(ICondition condition) : ICondition
{
    private readonly ICondition _condition = condition;

    public bool Check(SimpleParserResult result)
    {
        return !_condition.Check(result);
    }

    public static ICondition operator !(NotCondition condition)
    {
        return condition._condition;
    }
}