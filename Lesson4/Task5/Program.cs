/*Написать программу, конвертирующую римские числа в арабские*/

using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetArabicInt("IX")); // 9
            Console.WriteLine(GetArabicInt("XX")); // 20
            Console.WriteLine(GetArabicInt("XCIX")); // 99
            Console.WriteLine(GetArabicInt("MCCXXXIV")); // 1234
            Console.WriteLine(GetArabicInt("MMMCMXCIX")); // 3999
        }

        static int GetArabicInt(string roman)
        {
            int result = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int curDigit = EncodeRoman(roman[i]);
                if (i < roman.Length - 1 && EncodeRoman(roman[i + 1]) > EncodeRoman(roman[i]))
                    curDigit *= -1;
                
                result += curDigit;
            }

            return result;
        }

        static int EncodeRoman(char rChar)
        {
            switch (rChar)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
