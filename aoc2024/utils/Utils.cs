namespace aoc2024.utils;

public class Utils
{
    public static string[] SplitByLines(string input)
    {
        var splitted = input.Split(
            [Environment.NewLine],
            StringSplitOptions.None
        );

        var clean = splitted.Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToArray();
        return clean;
    }
}