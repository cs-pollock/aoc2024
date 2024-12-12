using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class Day05Test
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\05\input.txt""";
    private const string TEST_INPUT_LOCATION = """D:\code\aoc2024\aoc2024\05\testInput.txt""";

    [TestMethod]
    public void TestA()
    {
        var solution = Day05.RunA(Utils.GetInputFromFile(TEST_INPUT_LOCATION));
        Assert.AreEqual(143, solution);
    }

    [TestMethod]
    public void SolveA()
    {
        var solution = Day05.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(4959, solution);
    }

    [TestMethod]
    public void SolveB()
    {
        var solution = Day05.RunB(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(0, solution);
    }
}