using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class OneTest
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\01\input.txt""";

    [TestMethod]
    public void RunA()
    {
        var result = One.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(1830467, result);
    }

    [TestMethod]
    public void RunB()
    {
        var result = One.RunB(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(26674158, result);
    }
}