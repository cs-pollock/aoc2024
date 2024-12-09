using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class TwoTest
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\02\input.txt""";

    [TestMethod]
    public void SolveA()
    {
        var solution = Two.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
    }

    [TestMethod]
    public void SolveB()
    {
        
    }
}