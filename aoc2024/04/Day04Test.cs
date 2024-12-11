using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class Day04Test
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\04\input.txt""";
    [TestMethod]
    public void SolveA()
    {
        var solution = Day04.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(0, solution);
    }

    [TestMethod]
    public void SolveB()
    {
        var solution = Day04.RunB(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(0, solution);
    }
}