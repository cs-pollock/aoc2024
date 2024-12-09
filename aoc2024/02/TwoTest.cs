using aoc2024.utils;

namespace aoc2024;

[TestClass]
public class TwoTest
{
    private const string INPUT_LOCATION = """D:\code\aoc2024\aoc2024\02\input.txt""";

    [TestMethod]
    [DataRow(new int[] {7, 6, 4, 2, 1}, true)]
    [DataRow(new int[] {1, 2, 7, 8, 9}, false)]
    [DataRow(new int[] {9, 7, 6, 2, 1}, false)]
    [DataRow(new int[] {1, 3, 2, 4, 5}, false)]
    [DataRow(new int[] {8, 6, 4, 4, 1}, false)]
    [DataRow(new int[] {1, 3, 6, 7, 9}, true)]
    public void TestIsReportSafe(int[] report, bool IsReportSafe)
    {
        Assert.AreEqual(IsReportSafe, Two.IsReportSafe(report));
    }

    [TestMethod]
    public void SolveA()
    {
        var solution = Two.RunA(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(479, solution);
    }

    [TestMethod]
    public void SolveB()
    {
        var solution = Two.RunB(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(531, solution);
    }
}