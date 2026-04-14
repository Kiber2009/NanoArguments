namespace NanoArguments.Exceptions.Flag.KeyValue;

public class KeyValueFlagValueNotAllowedException(string key, string value)
    : CommandSyntaxException($"Value {value} not allowed for argument {key}");