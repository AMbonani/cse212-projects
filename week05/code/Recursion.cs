using System;
using System.Collections.Generic;
using System.Text;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? memo = null)
    {
        if (memo == null) memo = new Dictionary<int, decimal>();
        if (s < 0) return 0;
        if (s == 0) return 1;
        if (memo.ContainsKey(s)) return memo[s];

        memo[s] = CountWaysToClimb(s - 1, memo)
                + CountWaysToClimb(s - 2, memo)
                + CountWaysToClimb(s - 3, memo);
        return memo[s];
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int i = pattern.IndexOf('*');
        if (i == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, i) + "0" + pattern.Substring(i + 1), results);
        WildcardBinary(pattern.Substring(0, i) + "1" + pattern.Substring(i + 1), results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? path = null)
    {
        if (path == null) path = new List<(int, int)>();

        if (!maze.IsValidMove(x, y, path)) return;

        path.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(path.ToFormattedString());
            return;
        }

        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(path));
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(path));
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(path));
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(path));
    }
}
