using System;

namespace AffineCipher
{
    public class HelperMethods
    {
        public static int Gcd(int a, int b)
        {
            if (b > a)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            if (a % b == 0) return b;
            return Gcd(b, a % b);
        }
        public static Boolean IsItLetter(char symbol)
        {
            if (symbol >= 'a' && symbol <= 'z')
                return true;
            else if (symbol >= 'A' && symbol <= 'Z')
                return true;
            else
                return false;
        }
        public static int[] SplitKey(int key, int len)
        {
            const int alph = 26;

            //multiplicative cipher key
            int key0 = key / len;
            while (Gcd(key0, alph) != 1)
                key0--;

            //caesar cipher key
            int key1 = key % len;

            int[] newKey = {key0, key1};

            return newKey;
        }
    }
}
