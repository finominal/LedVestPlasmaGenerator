using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LedVestPlasmaGenerator.Validation
{
    public class Validator
    {
        public bool IsNumeric(string text)
        {
            var result = Regex.IsMatch(text, "[0-9]+");
            return result;
        }
    }
}
