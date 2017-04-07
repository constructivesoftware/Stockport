using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace StringCalculatorKata.App
{
    public class StringCalculator
    {
        public int Add(string numbers, char delimiter)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            return numbers.Split(delimiter).Where(x=>x.Length < 3).Sum(x => int.Parse(x));
        }

    }
}