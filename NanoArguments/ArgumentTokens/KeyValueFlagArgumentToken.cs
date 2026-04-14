namespace NanoArguments.ArgumentTokens;

public record KeyValueFlagArgumentToken(string Key, string Value) : IArgumentToken;