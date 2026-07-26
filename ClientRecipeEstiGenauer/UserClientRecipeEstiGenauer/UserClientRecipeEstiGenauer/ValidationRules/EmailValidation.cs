using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserClientRecipeEstiGenauer.ValidationRules
{
   public class EmailValidation:ValidationRule
    {

        public static bool IsEnglishLetter(Char c)
        {  //הפעולה מקבלת תו
           //הפעולה מחזירה אמת אם התו הוא באנגלית אחרת יחזיר שקר
            string s = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            if (s.Contains(c))
                return true;
            return false;
        }
        public static bool IsNumber(Char c)
        {  //הפעולה מקבלת תו
           //הפעולה מחזירה אמת אם התו הוא ספרה אחרת יחזיר שקר
            string s = "0987654321";
            if (s.Contains(c))
                return true;
            return false;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            if (s == null || s.Length == 0)
                return new ValidationResult(false, " Email is missing");
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (!IsEnglishLetter(s[i]) && !IsNumber(s[i]) && s[i] != '.' && s[i] != '_' && s[i] != '@')
                    return new ValidationResult(false, " The email address is incorrect, try again");
            }
            if (!IsEnglishLetter(s[0]) && !IsNumber(s[0]))
                return new ValidationResult(false, " The email address is incorrect, try again");
            if (!s.Contains('.'))
                return new ValidationResult(false, " The email address is incorrect, try again");
            if (!s.Contains('@'))
                return new ValidationResult(false, " The email address is incorrect, try again");
            int p1 = s.IndexOf('@');
            int p2 = s.LastIndexOf('.');

            if (p2 < p1)
                return new ValidationResult(false, " The email address is incorrect, try again");
            bool found = false;
            for (i = p1 + 1; i < p2; i++)
            {
                if (IsEnglishLetter(s[i]))
                    found = true;
            }
            if (found == false)
                return new ValidationResult(false, " The email address is incorrect, try again");
            if (!IsEnglishLetter(s[s.Length - 1]))
                return new ValidationResult(false, " The email address is incorrect, try again");

            return (ValidationResult.ValidResult);
        }



    }
}
