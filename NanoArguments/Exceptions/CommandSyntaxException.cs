using System;

namespace NanoArguments.Exceptions;

public class CommandSyntaxException(string message, uint? pos = null) : Exception(message)
{
    public uint? Pos { get; } = pos;
}