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
     * Complete the 'equal' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int equal(List<int> arr)
    {
          int min = arr.Min(); // Minimum value in the array
        int minOperations = int.MaxValue;

        // Check for targets: min, min-1, ..., min-4
        for (int baseTarget = min; baseTarget >= min - 4; baseTarget--)
        {
            int currentOperations = 0;

            foreach (int chocolates in arr)
            {
                int delta = chocolates - baseTarget;

                currentOperations += delta / 5; // Use 5s
                delta %= 5;

                currentOperations += delta / 2; // Use 2s
                delta %= 2;

                currentOperations += delta; // Use 1s
            }

            minOperations = Math.Min(minOperations, currentOperations);
        }

        return minOperations;
    }


    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.equal(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
