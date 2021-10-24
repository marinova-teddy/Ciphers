using System;

public class Program
{
	public static void Main()
	{
		Console.Write("Choose:\nEncryption - 1\nDecryption - 2\n");
		int task = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter your key: ");
		int key = Convert.ToInt32(Console.ReadLine());
		while (true)
		{
			if (key <= 0 || key >= 27)
			{
				Console.Write("Error. Please enter a valid key between 1 and 25: ");
				key = Convert.ToInt32(Console.ReadLine());
			}
			else
				break;
		}
		
		Console.WriteLine("Enter your message: ");
		string msg = Console.ReadLine();

		if (task == 1)
			Encryption(msg, key);
		else
			Decryption(msg, key);
		
	}
	public static bool IsSmallLetter(char symbol)
	{
		if (symbol <= 'z' && symbol >= 'a')
			return true;
		return false;
	}
	
	public static bool IsCapitalLetter(char symbol)
	{
		if (symbol <= 'Z' && symbol >= 'A')
			return true;
		return false;
	}
	
	public static bool IsDigit(char symbol)
	{
		if (symbol <= '9' && symbol >= '0')
			return true;
		return false;
	}

	public static void Encryption(string msg, int key)
	{
		string encMsg = "";
		
		for (int i = 0; i < msg.Length; i++)
		{
			int currChar = (int) msg[i] + key;
			//if spacebar
			if (msg[i]==' ') currChar=(int)' ';
			//if lowercase letter
			if ( IsSmallLetter(msg[i]) && !IsSmallLetter((char)currChar) ) currChar-=26;
			//if capital letter
			if ( IsCapitalLetter(msg[i]) && !IsCapitalLetter((char)currChar) ) currChar-=26;
			//if digit
			if ( IsDigit(msg[i]) && !IsDigit((char)currChar) ) {
				do {
					currChar-=10;
				} while (!IsDigit((char)currChar));
			}
			//if other symbol
			while ( (msg[i]!=' ') && !IsSmallLetter(msg[i]) && !IsCapitalLetter(msg[i]) && !IsDigit(msg[i]) &&
			   ( currChar==(int)' ' || IsSmallLetter((char)currChar) || IsCapitalLetter((char)currChar) || IsDigit((char)currChar)) ) {
				currChar+=key;
			}
			encMsg += (char) currChar;
		}

		Console.Write("This is your encrypted message: {0}", encMsg);
	}

	static void Decryption(string msg, int key)
	{
		string decMsg = "";
		
		for (int i = 0; i < msg.Length; i++)
		{
			int currChar = (int)msg[i] - key;
			//if spacebar
			if (msg[i]==' ') currChar=(int)' ';
			//if lowercase letter
			if ( IsSmallLetter(msg[i]) && !IsSmallLetter((char)currChar) ) currChar+=26;
			//if capital letter
			if ( IsCapitalLetter(msg[i]) && !IsCapitalLetter((char)currChar) ) currChar+=26;
			//if digit
			if ( IsDigit(msg[i]) && !IsDigit((char)currChar) ) {
				do {
					currChar+=10;
				} while (!IsDigit((char)currChar));
			}
			//if other symbol
			while ( (msg[i]!=' ') && !IsSmallLetter(msg[i]) && !IsCapitalLetter(msg[i]) && !IsDigit(msg[i]) &&
			   ( currChar==(int)' ' || IsSmallLetter((char)currChar) || IsCapitalLetter((char)currChar) || IsDigit((char)currChar)) ) {
				currChar-=key;
			}
			decMsg += (char)currChar;
		}

		Console.WriteLine("Key: {0} -> Message: {1}", key, decMsg);
	}
}
