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
			Console.WriteLine(decMsg);
			//multiplicative cipher
			decMsg = MultiplicativeCipher.Decryption(decMsg, cipherKey[0]);
			//output encrypted message
			Console.WriteLine(decMsg);
		}
	}

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

			if (b == 0)
				return a;
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
			if (key1 >= alph)
				key1 %= alph;
			int[] newKey = {key0, key1};
			return newKey;
		}
		public static Boolean Letter(int a)
		{
			if (a>=1 && a<=26) return true;
			else return false;
		}
		public static int CeasSymbolDecr(int sym, int key, int alph)
		{
			int decSym = sym - key;
			while (!Letter(decSym)) 
				decSym+=alph;
			
			return decSym;
		}
		public static Boolean WholeNumber(double a)
		{
			if (Math.Floor(a)==a) return true;
			else return false;
		}
		public static int MultSymbolDecr(double sym, int key, int alph)
		{
			double decSym = (double) sym/key;
			while (!WholeNumber(decSym)) 
			{
				sym+=alph;
				decSym = (double) sym/key;
			}
			
			return (int) decSym;
		}
	}

	public class CaesarCipher
	{
		public static string Encryption(string msg, int key)
		{
			string encMsg = "";
			const int alph = 26;
			for (int i = 0; i < msg.Length; i++)
			{
				if (msg[i] <= 'z' && msg[i] >= 'a')
					encMsg += (char)('a' + (((int)msg[i] - 'a') + key) % alph);
				else if (msg[i] <= 'Z' && msg[i] >= 'A')
					encMsg += (char)('A' + (((int)msg[i] - 'A') + key) % alph);
				else
					encMsg += (char)msg[i];
			}
			
			return encMsg;
		}

		public static string Decryption(string msg, int key)
		{
			string decMsg = "";
			const int alph = 26;
			for (int i = 0; i < msg.Length; i++)
			{
				if (msg[i] <= 'z' && msg[i] >= 'a')
					decMsg += (char) ('a' + HelperMethods.CeasSymbolDecr(((int)msg[i] - 'a'), key, alph) );
				else if (msg[i] <= 'Z' && msg[i] >= 'A')
					decMsg += (char) ('A' + HelperMethods.CeasSymbolDecr(((int)msg[i] - 'A'), key, alph) );
				else
					decMsg += (char)msg[i];
			}

			return decMsg;
		}
	}

	public class MultiplicativeCipher
	{
		public static string Encryption(string msg, int key)
		{
			string encMsg = "";
			const int alph = 26;
			for (int i = 0; i < msg.Length; i++)
			{
				if (msg[i] <= 'z' && msg[i] >= 'a')
					encMsg += (char)('a' + ((int)msg[i] - 'a') * key % alph);
				else if (msg[i] <= 'Z' && msg[i] >= 'A')
					encMsg += (char)('A' + ((int)msg[i] - 'A') * key % alph);
				else
					encMsg += (char)msg[i];
			}

			return encMsg;
		}

		public static string Decryption(string msg, int key)
		{
			string decMsg = "";
			const int alph = 26;
			for (int i = 0; i < msg.Length; i++)
			{
				if (msg[i] <= 'z' && msg[i] >= 'a')
					decMsg += (char) ('a' + HelperMethods.MultSymbolDecr(((int)msg[i] - 'a'), key, alph) );
				else if (msg[i] <= 'Z' && msg[i] >= 'A')
					decMsg += (char) ('A' + HelperMethods.MultSymbolDecr(((int)msg[i] - 'A'), key, alph) );
				else
					decMsg += (char)msg[i];
			}
		
			return decMsg;
		}
	}
}
