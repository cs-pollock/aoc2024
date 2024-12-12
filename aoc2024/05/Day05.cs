using aoc2024.utils;

namespace aoc2024;

public class Day05
{
    public static int RunA(string input)
    {
        var (rules, updates) = ParseInput(input);

        var cannotGoBefore = rules.GroupBy(rule => rule[0], rule => rule[1])
            .ToDictionary(g => g.Key, g => g.ToList());
        var cannotGoAfter = rules.GroupBy(rule => rule[1], rule => rule[0])
            .ToDictionary(g => g.Key, g => g.ToList());

        List<int[]> validUpdates = [];
        foreach(var update in updates)
        {
            for (int i = 0; i < update.Length; i++)
            {
                int currentNumber = update[i];
                int[] numbersBefore = i == 0 ? [] : new ArraySegment<int>(update, 0, i).ToArray();
                int[] numbersAfter = i == update.Length - 1 ? [] : new ArraySegment<int>(update, i + 1, update.Length - (i + 1)).ToArray();

                if(cannotGoBefore.ContainsKey(currentNumber) && numbersBefore.Any(cannotGoBefore[currentNumber].Contains))
                    break;

                if(cannotGoAfter.ContainsKey(currentNumber) && numbersAfter.Any(cannotGoAfter[currentNumber].Contains))
                    break;

                if (i == update.Length - 1)
                    validUpdates.Add(update);
            }
        }

        return validUpdates.Aggregate(0, (result, update) => result + update[update.Length / 2]);
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
        return 0;
    }
}