using System;

namespace SubstitutionCipher
{
    class Alphabet
    {
        public string keySet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890,.;:'-_=+()[]{}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter your message:");
                string msg = Console.ReadLine();
                string newMsg;

                char mode;
                do
                {
                    Console.WriteLine("Encryption or Decryption? Enter E or D:");
                    mode = Convert.ToChar(Console.ReadLine());
                    if (mode == 'E' || mode == 'D') break;
                    Console.WriteLine("Wrong input.");
                }
                while (true);

                string key = generateRandomKey();
                if (mode == 'E')
                    newMsg = EncryptMessage(key, msg);
                else
                    newMsg = DecryptMessage(key, msg);

                Console.WriteLine("The new message is: " + newMsg);

                Console.WriteLine("Do you want to try again? Enter Yes or No:");
                string cont = Console.ReadLine();
                if (cont != "Yes") break;
            }
            while (true);
        }
        public static string generateRandomKey()
        {
            Alphabet a = new Alphabet();
            string key = a.keySet;
            Random rand = new Random();

            for (int i=0;i<key.Length;i++)
            {
                SwapValues(ref key, key[i], key[rand.Next(key.Length)]);
            }

            Console.WriteLine("Key is: " + key);
            return key;
        }
        public static string TranslateMessage(string key, string msg, string mode)
        {
            Alphabet a = new Alphabet();
            string newMsg = "", alph = a.keySet;
            if (mode == "encrypt")
                SwapValues(ref alph, ref key);

            //substitution cipher
            for (int i=0; i<msg.Length; i++)
            {
                int j = FindValueIndex(key, msg[i]);
                char newVal;
                if (j == -1)
                    newVal = msg[i];
                else 
                    newVal = alph[j];
                newMsg += newVal;
            }

            return newMsg;
        }
        public static string EncryptMessage(string key, string msg)
        {
            return TranslateMessage(key, msg, "encrypt");
        }
        public static string DecryptMessage(string key, string msg)
        {
            return TranslateMessage(key, msg, "decrypt");
        }
        public static void SwapValues(ref string str, char a, char b)
        {
            char placeholder = '~';
            str = str.Replace(a, placeholder);
            str = str.Replace(b, a);
            str = str.Replace(placeholder, b);
        }
        public static void SwapValues(ref string a, ref string b)
        {
            Console.WriteLine("Strings changed from " + a + " " + b);
            a = a + b;
            b = a.Substring(0, a.Length - b.Length);
            a = a.Substring(b.Length);
            Console.WriteLine("Strings changed to " + a + " " + b);
        }
        public static int FindValueIndex(string str, char val)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == val) return i;
            return -1;
        }
    }
}
