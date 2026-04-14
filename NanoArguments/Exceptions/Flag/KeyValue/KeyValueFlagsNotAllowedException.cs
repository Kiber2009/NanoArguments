using System.Collections.Generic;

namespace NanoArguments.Exceptions.Flag.KeyValue;

public class KeyValueFlagsNotAllowedException(IEnumerable<string> args)
    : CommandSyntaxException($"KeyValue arguments {string.Join(", ", args)} not allowed");