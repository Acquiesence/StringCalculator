using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        /// <summary>
        /// returns the sum of a delimiter seperated string of numbers
        /// </summary>
        /// <param name="numbers">delimiter seperated string of numbers</param>
        /// <returns>sum of numbers</returns>
        public static int Add(string numbers)
        {
            int total = 0;

            for (int i = 0; i < StringHelpers.StringToInts(numbers).Count(); i++)
            {
                total = total + StringHelpers.StringToInts(numbers).ElementAt(i);
            }
            return total;
        }

        //public static string ChangeDefaultDelimiter(string input)
        //{
        //    string customDelimiterIndicator = "//";
        //    string newline = "\n";

        //    string output = String.Empty;
        //    if (input.StartsWith(customDelimiterIndicator))
        //    {
        //        string defaultDelimiter = input.Substring(customDelimiterIndicator.Length, input.IndexOf("\n") - customDelimiterIndicator.Length);

        //        output = input.Replace(defaultDelimiter, ",");
        //        int newlineIndex = output.IndexOf(newline);
        //        output = output.Substring(newlineIndex, output.Length - newlineIndex);
        //    }
        //    return output;
        //}
    }
}
