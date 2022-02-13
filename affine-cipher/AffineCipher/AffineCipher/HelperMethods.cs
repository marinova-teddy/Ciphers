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
        public static int[] SplitKey(int key, int len)
        {
            const int alph = 26;

            //multiplicative cipher key
            int key0 = key / len;
            while (Gcd(key0, alph) != 1)
                key0--;

            //caesar cipher key
            int key1 = key % len;
            if (key1 >= 27)
                key1 %= 26;

            int[] newKey = {key0, key1};

            return newKey;
        }
    }
}
