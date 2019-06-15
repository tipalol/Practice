using System;

namespace Eleven
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Encryption encryption = new Encryption();
            string[] menuElements = {
                "Зашифровать текст",
                "Расшифровать текст"
            };
            Menu menu = new Menu(menuElements);
            string str;

            int input = menu.GetChoose();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        str = menu.GetString("текст, который будет зашифрован");
                        str = encryption.Encrypt(str);
                        Console.WriteLine($"Зашифрованный текст: {str}");
                        break;
                    case 2:
                        str = menu.GetString("текст, который будет расшифрован");
                        str = encryption.Encrypt(str);
                        Console.WriteLine($"Расшифрованный текст: {str}");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
            }
        }
    }
}
