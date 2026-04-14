using System;

namespace NanoArguments.Tree.Conditions;

public class PredicateCondition(Predicate<SimpleParserResult> predicate) : ICondition
{
    public bool Check(SimpleParserResult result)
    {
        return predicate(result);
    }
}