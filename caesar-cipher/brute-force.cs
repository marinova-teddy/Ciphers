using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter an encrypted message: ");
		string encMsg = Console.ReadLine();

        for (int i=1; i<26; i++)
        {
            Decryption(encMsg, i);
        }
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