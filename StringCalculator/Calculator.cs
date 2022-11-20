using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        private static readonly List<string> DefaultDelimiters = new List<string> { ",", "\n" };
        private const string CustomDelimiterIndicator = "//";
        public static int Add(string numbers)
        {
            if(numbers.StartsWith(CustomDelimiterIndicator))
            {
                numbers = ChangeDefaultDelimiter(numbers);
            }

            return StringHelpers.SumOfNumbers(numbers, DefaultDelimiters);
        }

        private static string ChangeDefaultDelimiter(string numbers)
        {
            //Getting all the custom delimiters, starting after the custom indicator and before \n. 
            string customDelimiters = numbers.Substring(CustomDelimiterIndicator.Length, numbers.IndexOf('\n') - CustomDelimiterIndicator.Length);

            //Getting the custom delimiters after removing [] from the string, then assign to list.
            List<string> splitCustomDelimiters = customDelimiters.Split('[').Select(x => x.TrimEnd(']')).ToList();

            //Removes empty string if custom delimiters gives us one.
            if (customDelimiters.Contains(string.Empty)) splitCustomDelimiters.Remove(string.Empty);
            
            //Adding the custom delimiters to the default delimiters array so we can get the sum of numbers without issues when we parse it to the class method.
            DefaultDelimiters.AddRange(splitCustomDelimiters);

            //Checking to see if we have multiple delimiters.
            var hasMultipleDelimiters = splitCustomDelimiters.Count > 1; 
            //If we have multiple delimiters, we will times the count by 2 in order to get the [] sum.
            var multipleDelimiterLength = hasMultipleDelimiters ? (splitCustomDelimiters.Count * 2) : 0;
            //We create the starting index of the number string which is the sum of all custom delimiters length + the [] sum.
            var startIndexOfString = CustomDelimiterIndicator.Length + 1 + splitCustomDelimiters.Sum(x => x.Length) + multipleDelimiterLength; 
            numbers = numbers.Substring(startIndexOfString);
            return numbers;
        }
    }
}
