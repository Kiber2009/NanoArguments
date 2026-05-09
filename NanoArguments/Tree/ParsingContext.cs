using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using NanoArguments.Exceptions.Flag;
using NanoArguments.Exceptions.Flag.KeyValue;

namespace NanoArguments.Tree;

public class ParsingContext(
    SimpleParserResult result,
    FrozenSet<string> boolTrueValues,
    FrozenSet<string> boolFalseValues,
    bool boolValuesCompareLowercase
)
{
    public SimpleParserResult ParserResult { get; } = result;
    public FrozenSet<string> BoolTrueValues { get; } = boolTrueValues;
    public FrozenSet<string> BoolFalseValues { get; } = boolFalseValues;
    public bool BoolValuesCompareLowercase { get; } = boolValuesCompareLowercase;

    private readonly Dictionary<string, object?> _arguments = new();

    private HashSet<char>? _allowedFlags = [];
    private HashSet<string>? _allowedLongFlags = [];
    private Dictionary<string, HashSet<string>?>? _allowedKeyValueArguments = new();

    public void AddArgument(string name, object? value)
    {
        _arguments.Add(name, value);
    }

    public T? GetArgument<T>(string name)
    {
        return (T?)_arguments[name];
    }

    public T GetArgumentNonNull<T>(string name)
    {
        return GetArgument<T>(name) ?? throw new NullReferenceException();
    }

    public void AllowFlags(ISet<char>? flags)
    {
        if (flags == null)
            _allowedFlags = null;
        else if (_allowedFlags != null)
            foreach (char flag in flags)
                _allowedFlags.Add(flag);
    }

    public void AllowLongFlags(ISet<string>? flags)
    {
        if (flags == null)
            _allowedLongFlags = null;
        else if (_allowedLongFlags != null)
            foreach (string flag in flags)
                _allowedLongFlags?.Add(flag);
    }

    public void AllowKeyValueArguments(IDictionary<string, ISet<string>?>? arguments)
    {
        if (arguments == null)
            _allowedKeyValueArguments = null;
        else if (_allowedKeyValueArguments != null)
            foreach ((string key, ISet<string>? value) in arguments)
                if (value == null)
                    _allowedKeyValueArguments[key] = null;
                else if (_allowedKeyValueArguments.TryGetValue(key, out HashSet<string>? tmp))
                {
                    if (tmp == null)
                        continue;
                    foreach (string s in value)
                        tmp.Add(s);
                }
                else
                    _allowedKeyValueArguments[key] = [..value];
    }

    public void CheckFlags()
    {
        List<string> flags = [];

        if (_allowedFlags != null)
            flags.AddRange(ParserResult.Flags.Intersect(_allowedFlags).Select(flag => flag.ToString()));

        if (_allowedLongFlags != null)
            flags.AddRange(ParserResult.LongFlags.Intersect(_allowedLongFlags).Select(flag => flag.ToString()));

        if (flags.Count > 0)
            throw new FlagsNotAllowedException(flags.ToArray());

        if (_allowedKeyValueArguments == null)
            return;

        List<string> args = [];

        foreach ((string key, string value) in ParserResult.KeyValueFlags)
        {
            if (!_allowedKeyValueArguments.TryGetValue(key, out HashSet<string>? tmp))
            {
                args.Add(key);
                continue;
            }

            if (tmp == null)
                continue;
            if (!tmp.Contains(value))
                throw new KeyValueFlagValueNotAllowedException(key, value);
        }

        if (args.Count > 0)
            throw new KeyValueFlagsNotAllowedException(args);
    }
}