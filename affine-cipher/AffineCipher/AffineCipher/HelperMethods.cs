using System;
namespace AffineCipher
{
    public class GCD
    {
        public int Gcd(int a, int b)
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
    }
}
