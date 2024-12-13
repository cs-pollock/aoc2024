using aoc2024.utils;

namespace aoc2024;

public class Day05
{
    private static Dictionary<int, List<int>> cannotGoBefore;
    private static Dictionary<int, List<int>> cannotGoAfter;

    public static int RunA(string input)
    {
        var (rules, updates) = ParseInput(input);
        OrderRules(rules);

        return AddMiddlePositions(SortUpdates(updates).valid.ToArray());
    }

    private static int AddMiddlePositions(int[][] updates)
    {
        return updates.Aggregate(0, (result, update) => result + update[update.Length / 2]);
    }

    public static void SetUp(string input)
    {
        var (rules, _) = ParseInput(input);
        OrderRules(rules);
    }

    private static void OrderRules(int[][] rules)
    {
        cannotGoBefore = rules.GroupBy(rule => rule[0], rule => rule[1])
            .ToDictionary(g => g.Key, g => g.ToList());
        cannotGoAfter = rules.GroupBy(rule => rule[1], rule => rule[0])
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    private static (List<int[]> valid, List<int[]> invalid) SortUpdates(int[][] updates)
    {
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

                if (numbersBefore.Any(GetCannotGoBeforeRules(currentNumber).Contains))
                {
                    isValid = false;
                    break;
                }

                if (numbersAfter.Any(GetCannotGoAfterRules(currentNumber).Contains))
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
        var (rules, updates) = ParseInput(input);
        OrderRules(rules);
        (_, var invalidUpdates) = SortUpdates(updates);
        int[][] fixedUpdates = invalidUpdates.Select(FixUpdate).ToArray();
        return AddMiddlePositions(fixedUpdates);
    }

    public static int[] FixUpdate(int[] invalidUpdate)
    {
        int[] pendingNumbers = [.. invalidUpdate];
        List<int> fixedUpdate = [];

        while(pendingNumbers.Length > 0)
        {
            int nextValid = GetNextValidNumber(pendingNumbers);
            pendingNumbers = pendingNumbers.Where(number => number != nextValid).ToArray();
            fixedUpdate.Add(nextValid);
        }

        return [.. fixedUpdate];
    }

    private static int[] FixUpdate2(int[] invalidUpdate)
    {
        var validUpdate = (int[]) invalidUpdate.Clone();
        validUpdate.ToList().Sort(SortingAlg);
        return validUpdate;
    }

    private static int SortingAlg(int current, int other)
    {
        return 1;
    }

    private static int GetNextValidNumber(int[] pendingNumbers)
    {
        for (int i = 0; i < pendingNumbers.Length; i++)
        {
            int currentNumber = pendingNumbers[i];
            if (CanGoBefore(
                currentNumber,
                pendingNumbers.Where(x => x != currentNumber).ToArray()))
                return currentNumber;
        }

        throw new Exception("No number satifies all conditions");
    }

    private static bool CanGoBefore(
        int numberToCheck,
        int[] restOfNumbers)
    {
        foreach(var number in restOfNumbers)
        {
            if (GetCannotGoAfterRules(numberToCheck).Contains(number))
                return false;

            if(GetCannotGoBeforeRules(number).Contains(numberToCheck))
                return false;
        }

        return true;
    }

    private static List<int> GetCannotGoBeforeRules(int number)
    {
        return cannotGoBefore.ContainsKey(number) ? cannotGoBefore[number] : [];
    }

    private static List<int> GetCannotGoAfterRules(int number)
    {
        return cannotGoAfter.ContainsKey(number) ? cannotGoAfter[number] : [];
    }
}