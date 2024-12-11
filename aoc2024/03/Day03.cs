using System.Text.RegularExpressions;

namespace aoc2024;

public class Day03
{
    public static int RunA(string input)
    {
        var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");
        return matches.Aggregate(0, (result, current) => 
            result +
            int.Parse(current.Groups[1].Value)
            * int.Parse(current.Groups[2].Value)
        );
    }

    public static int RunB(string input)
    {
        var clean = Regex.Replace(input, @"(?=don't\(\)).+?((?=do\(\))|$)", string.Empty, RegexOptions.Singleline);
        return RunA(clean);
    }
}