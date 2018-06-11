using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IntegerArrayGrouper
{
    public class IntegerArrayHelper
    {
        public bool Validate(string input)
        {
            var regex = new Regex(@"^\[\d+(,\d+)+\]$");
            return regex.IsMatch(input);
        }

        public IEnumerable<int> Parse(string input)
        {
            input = input.Substring(1, input.Length - 2);
            return input.Split(',').Select(x => Convert.ToInt32(x));
        }

        public string Format(IEnumerable<int> input)
        {
            return "[" + String.Join(",", input.Select(x => x.ToString())) + "]";
        }
    }
}