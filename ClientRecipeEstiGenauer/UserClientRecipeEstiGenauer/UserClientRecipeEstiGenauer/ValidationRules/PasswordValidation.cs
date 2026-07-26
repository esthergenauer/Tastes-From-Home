using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserClientRecipeEstiGenauer.ValidationRules
{
   public class PasswordValidation:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;

            if (s.Length < 3)
                return new ValidationResult(false, "The password must contain at least 3 characters");


            if (!s.Contains('0') && !s.Contains('1') && !s.Contains('2') && !s.Contains('3') && !s.Contains('4') && !s.Contains('5') && !s.Contains('6') && !s.Contains('7') && !s.Contains('8') && !s.Contains('9'))

                return new ValidationResult(false, "The password must contain at least one digit");
            else
                return (ValidationResult.ValidResult);
        }

    }
}
