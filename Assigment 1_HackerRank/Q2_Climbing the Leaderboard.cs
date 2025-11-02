using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
          // Remove duplicates and sort the leaderboard in descending order
        List<int> uniqueRanked = ranked.Distinct().ToList();
        uniqueRanked.Sort((a, b) => b.CompareTo(a));

        List<int> result = new List<int>();
        int rankIndex = uniqueRanked.Count - 1; // Start from the lowest rank

        foreach (int score in player)
        {
            // Move up the leaderboard for scores greater than the player's
            while (rankIndex >= 0 && score >= uniqueRanked[rankIndex])
            {
                rankIndex--;
            }
            // Player's rank is the next one after rankIndex
            result.Add(rankIndex + 2);
        }

        return result;
    }

    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}




