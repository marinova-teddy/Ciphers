using System;

namespace AffineCipher
{
    public class MultiplicativeCipher
    {
        public static string Encryption(string msg, int key)
        {
            string encMsg = "";
            const int alph = 26;

            for (int i=0; i<msg.Length; i++)
            {
                if (HelperMethods.IsItLetter(msg[i]))
                    encMsg += (char)(((int)msg[i]) * key % alph);
                else
                    encMsg += (char)msg[i];
            }

            return encMsg;
        }
    }
}
