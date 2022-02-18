using System;

public class HelperMethods
{
	public HelperMethods()
	{
	}
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
		int[] newKey = { key0, key1 };
		return newKey;
	}
}
