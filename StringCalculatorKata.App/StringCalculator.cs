using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using StringCalculatorKata.App;

namespace StringCalculatorKata.App
{
    public class StringCalculator
    {
        public int Add(string numbers, char delimiter)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            if (FirstSevenFibonacci(numbers, delimiter)) throw new FibonacciAlertException();

            foreach (var n in numbers.Split(delimiter))
            {
                var test = 0;
                if (!int.TryParse(n, out test))
                {
                    return 0;
                }
            }

            try
            {
                return numbers.Split(delimiter).Where(x => x.Length < 3).Sum(x => int.Parse(x));
            }
            catch (Exception)
            {
                return 0;
            }

        }

        private bool FirstSevenFibonacci(string s, char delimiter)
        {
            return s.Replace(" ", "").IndexOf("0,1,1,2,3,5,8".Replace(delimiter, ','), StringComparison.Ordinal) == 0;
        }


    }
}