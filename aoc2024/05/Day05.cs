using aoc2024.utils;

namespace aoc2024;

public class Day05
{
    public static int RunA(string input)
    {
        return SortUpdates(input)
            .valid
            .Aggregate(0, (result, update) => result + update[update.Length / 2]);
    }

    private static (List<int[]> valid, List<int[]> invalid) SortUpdates(string input)
    {
        var (rules, updates) = ParseInput(input);

        var cannotGoBefore = rules.GroupBy(rule => rule[0], rule => rule[1])
            .ToDictionary(g => g.Key, g => g.ToList());
        var cannotGoAfter = rules.GroupBy(rule => rule[1], rule => rule[0])
            .ToDictionary(g => g.Key, g => g.ToList());

        List<int[]> validUpdates = [];
        List<int[]> invalidUpdates = [];
        foreach (var update in updates)
        {
            bool isValid = false;
            for (int i = 0; i < update.Length; i++)
            {
                int currentNumber = update[i];
                int[] numbersBefore = i == 0 ? [] : new ArraySegment<int>(update, 0, i).ToArray();
                int[] numbersAfter = i == update.Length - 1 ? [] : new ArraySegment<int>(update, i + 1, update.Length - (i + 1)).ToArray();

                if (cannotGoBefore.ContainsKey(currentNumber) && numbersBefore.Any(cannotGoBefore[currentNumber].Contains))
                {
                    isValid = false;
                    break;
                }

                if (cannotGoAfter.ContainsKey(currentNumber) && numbersAfter.Any(cannotGoAfter[currentNumber].Contains))
                {
                    isValid = false;
                    break;
                }

                if (i == update.Length - 1)
                    validUpdates.Add(update);
            }

            if (isValid)
                validUpdates.Add(update);
            else
                invalidUpdates.Add(update);
        }

        return (validUpdates, invalidUpdates);
    }

    private static (int[][] rules, int[][]updates) ParseInput(string input)
    {
        string[] lines = input.Split(["\r\n\r\n"], StringSplitOptions.RemoveEmptyEntries);
        var rules = Utils.SplitByLines(lines[0])
            .Select(rule => rule.Split('|')
            .Select(int.Parse).ToArray())
            .ToArray();
        var updates = Utils.SplitByLines(lines[1])
            .Select(update => update.Split(',')
            .Select(int.Parse).ToArray())
            .ToArray();

        return (rules, updates);
    }

    public static int RunB(string input)
    {
        (_, var invalidUpdates) = SortUpdates(input);

        return 0;
    }
}