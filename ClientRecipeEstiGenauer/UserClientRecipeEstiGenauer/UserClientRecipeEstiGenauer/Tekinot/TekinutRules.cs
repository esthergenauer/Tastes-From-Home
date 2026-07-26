using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClientRecipeEstiGenauer.Tekinot
{
   public class TekinutRules
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
        public static bool ValidEmail(string s)
        {
          
            if (s == null || s.Length == 0)
                return false;
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (!IsEnglishLetter(s[i]) && !IsNumber(s[i]) && s[i] != '.' && s[i] != '_' && s[i] != '@')
                    return false;
            }
            if (!IsEnglishLetter(s[0]) && !IsNumber(s[0]))
                return false;
            if (!s.Contains('.'))
                return false;
            if (!s.Contains('@'))
                return false;
            int p1 = s.IndexOf('@');
            int p2 = s.LastIndexOf('.');

            if (p2 < p1)
                return false;
            bool found = false;
            for (i = p1 + 1; i < p2; i++)
            {
                if (IsEnglishLetter(s[i]))
                    found = true;
            }
            if (found == false)
                return false;
            if (!IsEnglishLetter(s[s.Length - 1]))
                return false;

            return (true);
        }
        public static  bool ValidPassword(string s)
        {


            if (s.Length < 3)
                return false;


            if (!s.Contains('0') && !s.Contains('1') && !s.Contains('2') && !s.Contains('3') && !s.Contains('4') && !s.Contains('5') && !s.Contains('6') && !s.Contains('7') && !s.Contains('8') && !s.Contains('9'))

                return false;
            else
                return true;
        }


    }
}
