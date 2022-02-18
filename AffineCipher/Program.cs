using System;

namespace AffineCipher
{
    public class Program
    {
		public static void Main(string[] args)
		{
			Console.WriteLine("Encryption or Decryption? Enter E or D: ");
			string task = Console.ReadLine();
			Console.WriteLine("Enter message: ");
			string msg = Console.ReadLine();
			Console.WriteLine("Enter key: ");
			int key = Convert.ToInt32(Console.ReadLine());
			if (task.Equals("E"))
				Encryption(msg, key);
			else if (task.Equals("D"))
				Decryption(msg, key);
		}

		public static void Encryption(string msg, int key)
		{
			//split key and check key for mult.cipher
			int[] cipherKey = new int[2];
			cipherKey = HelperMethods.SplitKey(key, msg.Length);
			//multiplicative cipher
			string encMsg = MultiplicativeCipher.Encryption(msg, cipherKey[0]);
			//caesar cipher
			encMsg = CaesarCipher.Encryption(encMsg, cipherKey[1]);
			//output encrypted message
			Console.WriteLine(encMsg);
		}

		public static void Decryption(string msg, int key)
		{
			//split key and check key for mult.cipher
			int[] cipherKey = new int[2];
			cipherKey = HelperMethods.SplitKey(key, msg.Length);
			//caesar cipher
			string decMsg = CaesarCipher.Decryption(msg, cipherKey[1]);
			//multiplicative cipher
			decMsg = MultiplicativeCipher.Decryption(decMsg, cipherKey[0]);
			//output encrypted message
			Console.WriteLine(decMsg);
		}
	}
}
