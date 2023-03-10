using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_warsztat
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            var separators = new List<char> { ',', '\n' };

            if (str.StartsWith("//") && str[3] == '\n')
            {
                separators.Add(str[2]);
                str = str.Substring(4);
            }

            var numbers = str.Split(separators.ToArray());
            return numbers.Sum(i =>
            {
                var number = int.Parse(i);
                if (number < 0)
                    throw new ArgumentException();
                return number <= 1000 ? number : 0;
            });
        }
    }
}
