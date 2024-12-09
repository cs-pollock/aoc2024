using aoc2024.utils;

namespace aoc2024;

public class Two()
{
    public static int RunA(string input)
    {
        var lines = Utils.SplitByLines(input);
        var reports = lines.Select(line => line.Split(' ').Select(int.Parse));

        return reports.Aggregate(0, (result, report) =>
            IsReportSafe(report.ToArray()) ? ++result : result
        );
    }

    public static bool IsReportSafe(int[] report)
    {
        var isPositive = false;
        for (int i = 0; i < report.Count() - 1; i++)
        {
            var currentDistance = report[i] - report[i + 1];
            if (i == 0)
                isPositive = int.IsPositive(currentDistance);

            if (int.Abs(currentDistance) > 3
                || int.Abs(currentDistance) == 0
                || isPositive != int.IsPositive(currentDistance))
                return false;
        }

        return true;
    }
}