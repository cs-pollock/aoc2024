using aoc2024.utils;

public class One
{
    public static int RunA(string dataStream)
    {
        var lines = Utils.SplitByLines(dataStream);

        List<int> collectionA = [];
        List<int> collectionB = [];
        foreach(var line in lines)
        {
            var splitted = line.Split("   ");
            collectionA.Add(int.Parse(splitted[0]));
            collectionB.Add(int.Parse(splitted[1]));
        }

        collectionA = [.. collectionA.OrderDescending()];
        collectionB = [.. collectionB.OrderDescending()];

        int totalDistance = 0;
        for (int i = 0; i < collectionA.Count; i++)
        {
            totalDistance += Math.Abs(collectionA[i] - collectionB[i]);
        }

        return totalDistance;
    }


    public static int RunB(string dataStream)
    {
        return 0;
    }
}