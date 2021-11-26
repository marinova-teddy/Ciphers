using System;

namespace AffineCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message: ");
            string msg = Console.ReadLine();
            Console.WriteLine("Enter key: ");
            int key = Convert.ToInt32(Console.ReadLine());

            //split key and check key for mult.cipher
            int[] cipherKey = new int[2];
            cipherKey = HelperMethods.SplitKey(key, msg.Length);

            //multiplicative cipher
            string encMsg = MultiplicativeCipher.Encryption(msg, cipherKey[0]);

            //caesar cipher
            //encMsg = CaesarCipher.Encryption(encMsg, cipherKey[1]);

            //output encrypted message
            Console.WriteLine(encMsg);
        }
    }
}
