using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;

namespace NanoArguments.Tree.Conditions.Flag;

public class KeyValueFlagCondition(IDictionary<string, ISet<string>?> values) : ICondition
{
    private readonly IDictionary<string, ISet<string>?> _values = values;

    public bool Check(SimpleParserResult result)
    {
        foreach ((string key, string value) in result.KeyValueFlags)
        {
            if (!_values.TryGetValue(key, out ISet<string>? val))
                return false;

            if (val == null)
                continue;

            if (!val.Contains(value))
                return false;
        }

        return true;
    }

    public static KeyValueFlagCondition operator |(KeyValueFlagCondition left, KeyValueFlagCondition right)
    {
        Dictionary<string, ISet<string>?> res = left._values.ToDictionary();
        foreach ((string key, ISet<string>? value) in right._values)
        {
            if (!res.TryGetValue(key, out ISet<string>? lVal))
            {
                res[key] = value;
                continue;
            }

            if (lVal != null && value != null)
                res[key] = lVal.Union(value).ToFrozenSet();
        }

        return new(res);
    }

    public static KeyValueFlagCondition operator &(KeyValueFlagCondition left, KeyValueFlagCondition right)
    {
        Dictionary<string, ISet<string>?> res = new();

        foreach ((string key, ISet<string>? value) in left._values)
        {
            if (!right._values.TryGetValue(key, out ISet<string>? rVal))
                continue;

            if (rVal == null)
            {
                res[key] = value;
                continue;
            }

            if (value == null)
            {
                res[key] = rVal;
                continue;
            }

            FrozenSet<string> tmp = value.Intersect(rVal).ToFrozenSet();
            if (tmp.Count == 0)
                continue;
            res[key] = tmp;
        }

        return new(res);
    }
}