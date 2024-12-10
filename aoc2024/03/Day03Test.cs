using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class Day03Test
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\03\input.txt""";
    [TestMethod]
    public void RunA()
    {
        var solution = Day03.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(174561379, solution);
    }

    [TestMethod]
    public void RunB()
    {
        
    }
}