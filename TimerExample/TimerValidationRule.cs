using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TimerExample
{
    public class TimerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || !double.TryParse(value.ToString(), out _))
                return new ValidationResult(false, "Please input a valid number");
            else if (double.Parse(value.ToString()) < 0)
                return new ValidationResult(false, "Please input a positive number");

            return new ValidationResult(true, null);
        }
    }
}
