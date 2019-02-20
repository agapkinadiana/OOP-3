using System;
namespace lab8
{
    public class User
    {
        public delegate void Shift(int offset);
        public event Shift ShiftEvent;

        public delegate void Сompression(int comprCoef);
        public event Сompression CompressionEvent;

        public void ShiftOrCompr(bool ques, int coef)
        {
            if (ques)
                ShiftEvent(coef);
            else
                CompressionEvent(coef);
        }


        public static string RemoveCommasDotes(string str)
        {
            string result = "";
            foreach (char ch in str)
            {
                if (ch == ',' || ch == '.')
                    continue;
                result += ch;
            }
            return result;
        }

        public static string AddSymbols(string str)
        {
            string result = "!";
            result = result + str + result;
            return result;
        }

        public static string ToUpperCase(string str) => str.ToUpper();
        public static string RemoveSpaces(string str)
        {
            string result = "";
            foreach (char ch in str)
            {
                if (ch == ' ')
                    continue;
                result += ch;
            }
            return result;
        }

        public static string AfterFirstWord(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                {
                    result = str.Substring(i);
                    break;
                }
            return result;
        }

        public static string ToBinary(string str)
        {
            string result = "";
            foreach (byte ch in str)
                result += Convert.ToString(ch, 2);
            return result;
        }
    }
}
