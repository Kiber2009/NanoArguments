using System.Collections.Generic;

namespace NanoArguments.Exceptions.Flag;

public class FlagsNotAllowedException(IEnumerable<string> flags)
    : CommandSyntaxException($"Flags {string.Join(", ", flags)} not allowed");