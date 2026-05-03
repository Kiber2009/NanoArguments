using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace NanoArguments;

public static class Utils
{
    public static bool IsValidPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        try
        {
            string fullPath = Path.GetFullPath(path);

            string[] parts = fullPath.Split(
                [Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar],
                StringSplitOptions.RemoveEmptyEntries);

            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? ValidateWindows(parts, fullPath)
                : ValidateUnix(parts);
        }
        catch
        {
            return false;
        }
    }

    private static bool ValidateWindows(string[] parts, string fullPath)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();

        foreach (string part in parts)
        {
            if (part.IndexOfAny(invalidChars) >= 0)
                return false;

            if (part.EndsWith(' ') || part.EndsWith('.'))
                return false;

            if (IsReservedWindowsName(part.TrimEnd('.').ToUpperInvariant()))
                return false;
        }

        return fullPath.Count(c => c == ':') <= 1;
    }

    private static bool IsReservedWindowsName(string name)
    {
        if (name is "CON" or "PRN" or "AUX" or "NUL")
            return true;

        return name.Length == 4 &&
               (name.StartsWith("COM") || name.StartsWith("LPT")) &&
               char.IsDigit(name[3]) &&
               name[3] != '0';
    }

    private static bool ValidateUnix(string[] parts)
    {
        return parts.All(part => !part.Contains('\0'));
    }
}