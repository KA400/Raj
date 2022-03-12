using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("What is your message?");
        string realMsg = Console.ReadLine();
        string encrMsg = Program.Encrypt(realMsg);
        Console.WriteLine("Encrypted message: {0}", encrMsg);
        Program.BruteDecrypt(encrMsg);
	}
    static string Encrypt(string msg)
    {
        Random rnd = new Random();
        int key  = rnd.Next(msg.Length*5/100,msg.Length*15/100);
        char[,] cipherChar = new char [msg.Length/key,key];
        //Console.WriteLine("Rows {0} Cols {1}",msg.Length/key,key);
        for(int rows = 0, i = 0; rows<msg.Length/key; ++rows)
        {
            for(int cols = 0; cols<key; ++cols, ++i)
            {
                if (i>=msg.Length)
                {
                    cipherChar[rows,cols] = '~';
                    //Console.WriteLine('~');
                }
                else
                {
                    cipherChar[rows,cols] = msg[i];
                    //Console.WriteLine(msg[i]);
                }
            }        
        }
        char[] longCipherChar = new char [cipherChar.Length];
        for(int cols = 0, i = 0; cols<cipherChar.GetLength(1); ++cols)
        {
            for(int rows = 0; rows<cipherChar.GetLength(0); ++rows, ++i)
            {
                longCipherChar[i] = cipherChar[rows,cols];
                Console.WriteLine(longCipherChar[i]);
                //Console.WriteLine(i);
            }        
        }  
        string cipherText = new string(longCipherChar);
        return cipherText;
    }
    static void BruteDecrypt(string msg)
    {
        Console.WriteLine("Decryption:");
        for (int key = msg.Length*5/100; key<=msg.Length*15/100; ++key)
        {
            char[,] cipherChar = new char [msg.Length/key,key];
            for(int cols = 0, i = 0; cols<key; ++cols)
            {
                for(int rows = 0; rows<msg.Length/key; ++rows, i++)
                {
                    if (i>=msg.Length)
                    {
                        cipherChar[rows,cols] = '~';
                    }
                    else
                    {
                        cipherChar[rows,cols] = msg[i];
                    }
                }        
            }
            char[] longCipherChar = new char [cipherChar.Length];
            for(int rows = 0, i = 0; rows<msg.Length/key; ++rows)
            {
                for(int cols = 0; cols<key; ++cols, ++i)
                {
                    longCipherChar[i] = cipherChar[rows,cols];
                }        
            }  
            string cipherText = new string(longCipherChar);
            Console.WriteLine("Key: {0}", key);
            Console.WriteLine(cipherText);
        }
    }
}
