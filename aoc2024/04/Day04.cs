using aoc2024.utils;

namespace aoc2024;

public class Day04
{
    private static int maxI;
    private static int maxJ;
    private static  char[][] charMatrix;

    public static int RunA(string input)
    {
        SetUp(input);

        int result = 0;
        for (int i = 0; i < charMatrix.Length; i++)
            for (int j = 0; j < charMatrix[i].Length; j++)
                result += FindWholeWordMatchesFromPosition2(['X', 'M', 'A', 'S'], new (i, j));

        return result;
    }

    private static void SetUp(string input)
    {
        charMatrix = GetCharMatrix(input);
        maxI = charMatrix.Length - 1;
        maxJ = charMatrix[0].Length - 1;
    }

    private record Position(int I, int J)
    {
        public Position Add(Position other) => new(I + other.I, J + other.J);
    }

    private static readonly Position[] SearchVectors = [
        new (- 1, 1),
        new (- 1, 0),
        new (- 1,- 1),

        new (0, 1),
        new (0,- 1),

        new (1, 1),
        new (1, 0),
        new (1,- 1),
    ];

    private static readonly Position[] XMasSearchVectorsA = [
        new (- 1,- 1),
        new (1, 1),
    ];

    private static readonly Position[] XMasSearchVectorsB = [
        new (- 1, 1),
        new (1,- 1),
    ];

    private static char? GetCharAtPosition(Position position)
    {
        if (!IsPositionValid(position))
            return null;

        return charMatrix[position.I][position.J];
    }

    private static int FindWholeWordMatchesFromPosition2(
        char[] word,
        Position initialPosition)
    {
        if (word.Length < 2)
            return 0;

        int matches = 0;
        foreach (var searchVector in SearchVectors)
        {
            if (GetCharAtPosition(initialPosition) != word[0])
                continue;

            Position currentPosition = initialPosition;
            for (int k = 1; k < word.Length; k++)
            {
                currentPosition = currentPosition.Add(searchVector);
                if (GetCharAtPosition(currentPosition) != word[k])
                    break;

                if (k == word.Length - 1)
                    matches++;
            }
        }

        return matches;
    }

    
    // This algorithm is incorrect, since it searches for words in every direction
    // allowing changing direction along the way.
    private static int FindWholeWordMatchesFromPosition(char[][] charMatrix, char[] word, int i, int j)
    {
        if (charMatrix[i][j] != word[0])
            return 0;

        Position[] positions = [new (i, j)];
        for (int k = 1; k < word.Length; k++)
        {
            List<Position> newPositions = [];
            foreach(var position in positions)
                newPositions.AddRange(GetPositionsWithNextLetter(charMatrix, word[k], position.I, position.J));

            if (newPositions.Count == 0)
                return 0;
                
            positions = [.. newPositions];
        }

        return positions.Length;
    }

    private static Position[] GetPositionsWithNextLetter(char[][] charMatrix, char letter, int i, int j)
    {
        Position[] positionsToSearch = [
            new (i - 1, j + 1),
            new (i - 1, j),
            new (i - 1, j - 1),

            new (i, j + 1),
            new (i, j - 1),

            new (i + 1, j + 1),
            new (i + 1, j),
            new (i + 1, j - 1),
        ];

        return positionsToSearch
            .Where(position =>
                IsPositionValid(position)
                && charMatrix[position.I][position.J] == letter)
            .ToArray();
    }

    private static bool IsPositionValid(Position position)
    {
        int i = position.I;
        int j = position.J;

        return i >= 0 && j >= 0 && i <= maxI && j <= maxJ;
    }

    private static char[][] GetCharMatrix(string input)
    {
        var lines = Utils.SplitByLines(input);
        return lines.Select(line => line.ToCharArray()).ToArray();
    }

    public static int RunB(string input)
    {
        SetUp(input);

        int result = 0;
        for (int i = 0; i < charMatrix.Length; i++)
            for (int j = 0; j < charMatrix[i].Length; j++)
                result += FindXMasInstancesFromPosition(new (i, j));

        return result;
    }

    private static int FindXMasInstancesFromPosition(Position position)
    {
        if (GetCharAtPosition(position) != 'A')
            return 0;

        List<char?> validChars = ['M', 'S'];
        var a1 = GetCharAtPosition(position.Add(XMasSearchVectorsA[0]));
        var a2 = GetCharAtPosition(position.Add(XMasSearchVectorsA[1]));

        var b1 = GetCharAtPosition(position.Add(XMasSearchVectorsB[0]));
        var b2 = GetCharAtPosition(position.Add(XMasSearchVectorsB[1]));

        if (validChars.Contains(a1)
            && validChars.Contains(a2)
            && validChars.Contains(b1)
            && validChars.Contains(b2)
            && a1 != a2
            && b1 != b2
        ) return 1;

        return 0;
    }
}