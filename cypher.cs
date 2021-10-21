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
				Console.Write("Error. Please enter a valid key: ");
				key = Convert.ToInt32(Console.ReadLine());
			}
			else
				break;
		}

		if (task == 1)
			Encryption(key);
		else
			Decryption(key);
	}

	public static bool IsItSmallLetter(char symbol)
	{
		if (symbol <= 'z' && symbol >= 'a')
			return true;
		else
			return false;
	}
	
	public static bool IsItCapitalLetter(char symbol)
	{
		if (symbol <= 'Z' && symbol >= 'A')
			return true;
		else
			return false;
	}

	public static void Encryption(int key)
	{
		Console.WriteLine("Enter your message: ");
		string msg = Console.ReadLine();
		string encrptdMsg = "";
		for (int i = 0; i < msg.Length; i++)
		{
			int currChar = msg[i] + key;
			if (IsItSmallLetter(msg[i]) && !IsItSmallLetter((char)currChar)) currChar -= 26;
			if (!IsItSmallLetter(msg[i]) && IsItSmallLetter((char)currChar)) currChar += 26;
			if (IsItCapitalLetter(msg[i]) && !IsItCapitalLetter((char)currChar)) currChar -= 26;
			if (!IsItCapitalLetter(msg[i]) && IsItCapitalLetter((char)currChar)) currChar += 26;
			if (msg[i]==' ') { currChar = 32; Console.WriteLine("SPACEBAR");}
			encrptdMsg += (char)currChar;
		}

		Console.Write("This is your encrypted message: {0}", encrptdMsg);
	}

	static void Decryption(int key)
	{
		Console.WriteLine("Enter your message: ");
		string encrptdMsg = Console.ReadLine();
		string msg = "";
		for (int i = 0; i < encrptdMsg.Length; i++)
		{
			int currChar = encrptdMsg[i] - key;
			if (IsItSmallLetter(encrptdMsg[i]) && !IsItSmallLetter((char)currChar)) currChar += 26;
			if (!IsItSmallLetter(encrptdMsg[i]) && IsItSmallLetter((char)currChar)) currChar -= 26;
			if (IsItCapitalLetter(encrptdMsg[i]) && !IsItCapitalLetter((char)currChar)) currChar += 26;
			if (!IsItCapitalLetter(encrptdMsg[i]) && IsItCapitalLetter((char)currChar)) currChar -= 26;
			if (encrptdMsg[i]==' ') { currChar = 32; Console.WriteLine("SPACEBAR");}
			msg += (char)currChar;
		}

		Console.WriteLine("Message: {0}", msg);
	}
}
