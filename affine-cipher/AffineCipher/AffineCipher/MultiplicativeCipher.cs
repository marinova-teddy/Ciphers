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
                if (msg[i] >= 'A' && msg[i] >= 'Z')
                    encMsg += (char)('A'+((int)msg[i]) * key % alph);
                else if (msg[i]>='a' && msg[i]>='z')
                    encMsg += (char)('a' + ((int)msg[i]) * key % alph);
                else
                    encMsg += (char)msg[i];
            }

            return encMsg;
        }
    }
}
