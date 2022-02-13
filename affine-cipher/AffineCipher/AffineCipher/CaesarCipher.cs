using System;
namespace AffineCipher
{
    public class CaesarCipher
    {
		public static string Encryption(string msg, int key)
		{
			string encMsg = "";

			for (int i = 0; i < msg.Length; i++)
			{
				int currChar = (int)msg[i] + key;
				//if spacebar
				if (msg[i] == ' ') currChar = (int)' ';
				//if lowercase letter
				if ((msg[i] <= 'z' && msg[i] >= 'a') && !((char)currChar <= 'z' && (char)currChar >= 'a')) currChar -= 26;
				//if capital letter
				if ((msg[i] <= 'Z' && msg[i] >= 'A') && !((char)currChar <= 'Z' && (char)currChar >= 'A')) currChar -= 26;
				//if digit
				if ((msg[i] <= '9' && msg[i] >= '0') && !((char)currChar <= '9' && (char)currChar >= '0'))
				{
					do
					{
						currChar -= 10;
					} while (!((char)currChar <= '9' && (char)currChar >= '0'));
				}
				//if other symbol
				while ((msg[i] != ' ') && !(msg[i] <= 'z' && msg[i] >= 'a') && !(msg[i] <= 'Z' && msg[i] >= 'A') && !(msg[i] <= '9' && msg[i] >= '0') &&
				   (currChar == (int)' ' || ((char)currChar <= 'z' && (char)currChar >= 'a') || ((char)currChar <= 'Z' && (char)currChar >= 'A') || ((char)currChar <= '9' && (char)currChar >= '0')))
				{
					currChar += key;
				}
				encMsg += (char)currChar;
			}

			return encMsg;
		}

	}
}
