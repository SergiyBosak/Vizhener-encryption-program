using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigener
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = enterText("введите шифруемый текст:");

            string key = enterText("введите ключ:");

            text = encode(text, key);

            Console.WriteLine("Шифрованное сообщение");
            Console.WriteLine(text);

            Console.WriteLine("Нажмите любую клавишу, чтобы расшифровать");
            Console.ReadKey();

            Console.WriteLine(decode(text, key));

            Console.ReadKey();
        }

        static string Vigener(string text, string key, bool decode = false)
        {
            int textLength = text.Length;
            int keyLength = key.Length;
            char[] result = new char[textLength];
            int keyDecode = 1;
            if (decode)
                keyDecode = -keyDecode;
            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {              
                if (j == key.Length)
                    j = 0;
                result[i] = (char)(text[i] + keyDecode*key[j]);
            }
            return new string(result);
        }

        static string Vigener2(string text, string key, bool decode = false)
        {
            int textLength = text.Length;
            int keyLength = key.Length;
            char[] result = new char[textLength];
            int keyIndex = 0;
            int keyDecode = 1;
            if (decode)
                keyDecode = -keyDecode;
            for (int i = 0; i < textLength; i++)
            {
                result[i] = (char)(text[i] + keyDecode*key[keyIndex]);
                keyIndex = keyIndex + 1;
                if (keyIndex == keyLength)
                    keyIndex = 0;
            }
            return new string(result);
        }

        static string encode(string text, string key)
        {
            return Vigener(text, key);
        }

        static string decode(string text, string key)
        {
            return Vigener(text, key, true);
        }

        static string enterText(string text)
        {
            Console.WriteLine(text);
            do
            {
                text = Console.ReadLine();
                if (text.Trim() == string.Empty)
                    Console.Write("Вы не ввели ни одного символа, введите текст: \n" + text);
            }
            while (text.Trim() == string.Empty);

            return text;
        }
    }
}
