using aoc2024.utils;

namespace aoc2024;

public class One
{
    public static int RunA(string dataStream)
    {
        ParseInput(dataStream, out List<int> collectionA, out List<int> collectionB);

        int totalDistance = 0;
        for (int i = 0; i < collectionA.Count; i++)
        {
            totalDistance += Math.Abs(collectionA[i] - collectionB[i]);
        }

        return totalDistance;
    }

    private static void ParseInput(string dataStream, out List<int> collectionA, out List<int> collectionB)
    {
        var lines = Utils.SplitByLines(dataStream);

        collectionA = [];
        collectionB = [];
        foreach (var line in lines)
        {
            var splitted = line.Split("   ");
            collectionA.Add(int.Parse(splitted[0]));
            collectionB.Add(int.Parse(splitted[1]));
        }

        collectionA = [.. collectionA.OrderDescending()];
        collectionB = [.. collectionB.OrderDescending()];
    }

    public static int RunB(string dataStream)
    {
        ParseInput(dataStream, out List<int> collectionA, out List<int> collectionB);
        var result = collectionA.Aggregate(0, (result, currentA) => {
            var instances = collectionB.Aggregate(0, (instances, currentB) => currentB == currentA ? ++instances : instances);
            return result + currentA * instances;
        });

        return result;
    }
}