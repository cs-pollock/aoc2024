using aoc2024.utils;

namespace aoc2024;

public class Day02
{
    public static int RunA(string input)
    {
        return ParseInput(input).Aggregate(0, (result, report) =>
            IsReportSafe(report.ToArray()) ? ++result : result
        );
    }

    private static IEnumerable<IEnumerable<int>> ParseInput(string input)
    {
        var lines = Utils.SplitByLines(input);
        var reports = lines.Select(line => line.Split(' ').Select(int.Parse));
        return reports;
    }

    public static int RunB(string input)
    {
        var originalReports = ParseInput(input);
        var expandedReports = originalReports.Select(report => ExpandReport(report.ToArray()));
        return expandedReports.Aggregate(0, (result, reportCollection) =>
            reportCollection.Any(IsReportSafe) ? ++result : result
        );
    }

    private static List<int[]> ExpandReport(int[] report)
    {
        List<int[]> expandedReports = [];
        for (int i = 0; i < report.Length; i++)
        {
            List<int> expandedReport = [];
            for (int j = 0; j < report.Length; j++)
            {
                if (j == i)
                    continue;

                expandedReport.Add(report[j]);
            }
            expandedReports.Add([.. expandedReport]);
        }

        return expandedReports;
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