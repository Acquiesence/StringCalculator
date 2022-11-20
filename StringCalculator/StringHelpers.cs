using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringHelpers
    {
        public static int SumOfNumbers(string input, List<string> _defaultDelimiters)
        {
            try
            {
                //Splitting the string of numbers and converts into a list of integer numbers.
                var splitNumbers = input.Split(_defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                //Check to see if numbers are valid.
                ValidateNumbers(splitNumbers);
                //Return the sum of numbers.
                return splitNumbers.Sum();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //if any number is NOT less than 0, we return and continue on with the application, if any number is negative, we create a string of negative numbers to show in the exception message.
        private static void ValidateNumbers(IReadOnlyCollection<int> numbers)
        {
            if (!numbers.Any(x => x < 0)) return;

            var negativeNumbers = string.Join(",", numbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            throw new Exception($"Negative Numbers are not allowed. '{negativeNumbers}'");
        }
    }
}
