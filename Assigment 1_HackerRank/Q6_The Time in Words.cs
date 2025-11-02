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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        String words="";
        var unitsMap = new[] {  "","one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve","thirteen", "fourteen", "quarter", "sixteen", "seventeen", "eighteen", "nineteen","twenty" };
        var tensMap = new[] { "zero", "ten", "twenty"};
        int nextHour = (h == 12) ? 1 : h + 1;
        string minuteWord = (m == 1 ^ (60-m)==1) ? "minute" : "minutes";
        
        
        if (m==0){
            return words=unitsMap[h]+" "+"o'"+" "+"clock";
        }
        if(m==15){
            return words="quarter past"+" "+unitsMap[h];  
        }
        if(m==20){
            return words=unitsMap[m]+" "+minuteWord+ " past"+" "+unitsMap[h];  
        }
        if(m==30){
            return  words="half past"+" "+unitsMap[h];  
        }
        if(m==40){
            return  words="twenty to"+" "+unitsMap[nextHour];  
        }
        if(m==45){
            return words="quarter to"+" "+unitsMap[nextHour];
        }
        else if(m<20){
            return words=unitsMap[m]+" "+minuteWord+ "past"+" "+unitsMap[h];   
        }
        else if(m>20 && m<30){
            return words=unitsMap[(m/10)*10]+" "+unitsMap[m%10]+" "+minuteWord +" past"+" "+unitsMap[h]; 
        }
        else{
            if(60-m<20){
                   return words=unitsMap[60-m]+" "+minuteWord+ " to"+" "+unitsMap[nextHour];
            }
            else
            {
            return words=unitsMap[((60-m)/10)*10]+" "+unitsMap[10-(m%10)]+" "+minuteWord+" to"+" "+unitsMap[nextHour];
        }
        
        
        }
        return words;
      }

        
      

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
}
