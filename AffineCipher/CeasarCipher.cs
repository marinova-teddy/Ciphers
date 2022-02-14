using System;

namespace AffineCipher
{
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
          decMsg += (char)('a' + (((int)msg[i] - 'a') - key) % alph);
        else if (msg[i] <= 'Z' && msg[i] >= 'A')
          decMsg += (char)('A' + (((int)msg[i] - 'A') - key) % alph);
        else
          decMsg += (char)msg[i];
      }

      return decMsg;
    }
  }
}