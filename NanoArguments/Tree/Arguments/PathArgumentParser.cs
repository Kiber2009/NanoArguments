using System;
using System.IO;

namespace NanoArguments.Tree.Arguments;

public class PathArgumentParser : IArgumentParser<string>
{
    public static PathArgumentParser Instance { get; } = new();
    private PathArgumentParser() { }

    private readonly Filter _filter;

    public PathArgumentParser(Filter filter = Filter.Any)
    {
        if (!Enum.IsDefined(filter))
            throw new ArgumentOutOfRangeException(nameof(filter), filter, null);
        _filter = filter;
    }

    public bool Check(ParsingContext context, string value)
    {
        return _filter switch
        {
            Filter.Any => Utils.IsValidPath(value),
            Filter.NotExists => !Path.Exists(value),
            Filter.Exists => Path.Exists(value),
            Filter.ExistsFile => File.Exists(value),
            Filter.ExistsDirectory => Directory.Exists(value),
            _ => throw new ArgumentOutOfRangeException(null, _filter, null)
        };
    }

    public string Parse(ParsingContext context, string value)
    {
        return value;
    }

    public enum Filter : byte
    {
        Any,
        NotExists,
        Exists,
        ExistsFile,
        ExistsDirectory
    }
}