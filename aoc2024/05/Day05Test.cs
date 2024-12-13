using FluentAssertions;
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
    [DataRow(new int[] {75, 97, 47, 61, 53}, new int[] {97,75,47,61,53})]
    [DataRow(new int[] {61, 13, 29}, new int[] {61, 29, 13})]
    [DataRow(new int[] {97, 13, 75, 29, 47}, new int[] {97, 75, 47, 29, 13})]
    public void TestB(int[] invalidUpdate, int[] validUpdate)
    {
        Day05.SetUp(Utils.GetInputFromFile(TEST_INPUT_LOCATION));
        var fixedUpdate = Day05.FixUpdate(invalidUpdate);
        fixedUpdate.Should().BeEquivalentTo(validUpdate);
    }

    [TestMethod]
    public void SolveB()
    {
        var solution = Day05.RunB(Utils.GetInputFromFile(INPUT_LOCATION));
        Assert.AreEqual(9614, solution);
    }
}