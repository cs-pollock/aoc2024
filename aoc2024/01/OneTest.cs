namespace aoc2024;

[TestClass]
public class OneTest
{
    [TestMethod]
    public void RunA()
    {
        var result = One.RunA(GetInputFromFile());
        Assert.AreEqual(1830467, result);
    }

    [TestMethod]
    public void RunB()
    {
        var result = One.RunB(GetInputFromFile());
        Assert.AreEqual(0, result);
    }

    private static string GetInputFromFile()
    {
        StreamReader sr = new("""D:\code\aoc2024\aoc2024\01\input.txt""");
        var input = sr.ReadToEnd();

        if (input == null)
            throw new Exception("Input file null");

        return input;
    }
}