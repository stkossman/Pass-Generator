using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    public class PassEx
    {
        private string capital = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private string lower = "qwertyuiopasdfghjklzxcvbnm";
        private string digits = "0123456789";
        private string special = "!@#$%^&*(){}[]";
        private string all;

        public PassEx(bool includeCapital, bool includeLower, bool includeDigits, bool includeSpecial)
        {
            StringBuilder sb = new StringBuilder();
            if (includeCapital)
                sb.Append(capital);
            if (includeLower)
                sb.Append(lower);
            if (includeDigits)
                sb.Append(digits);
            if (includeSpecial)
                sb.Append(special);
            all = sb.ToString();
        }

        public int CalculateStrength(string pass)
        {
            int score = 0;

            if (pass.Length < 0)
                score = 0;
            else if (pass.Length < 10)
                score += 2;
            else
                score += 3;

            if (ContainsLowerCase(pass))
                score += 1;
            if (ContainsUpperCase(pass))
                score += 1;
            if (ContainsDigit(pass))
                score += 1;
            if (ContainsSpecialChar(pass))
                score += 1;

            return Math.Min(score, 10);
        }

        private bool ContainsLowerCase(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsUpperCase(string str)
        {
            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsDigit(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private bool ContainsSpecialChar(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }
            return false;
        }

        public string GetLevel(int score)
        {
            if (score <= 3)
                return "simple";
            else if (score <= 7)
                return "medium";
            else
                return "strong";
        }

        public string GeneratePassword(int passLen)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < passLen; i++)
            {
                sb.Append(all[rand.Next(all.Length)]);
            }
            return sb.ToString();
        }
    }
}
