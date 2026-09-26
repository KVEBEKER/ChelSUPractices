using System.Text;

namespace P27_09_26_cool_console_menu
{
    internal class Program
    {
        static bool Inverted = false;
        static ConsoleColor Black = ConsoleColor.Black;
        static ConsoleColor White = ConsoleColor.White;
        static ConsoleColor Red = ConsoleColor.Red;
        static ConsoleColor Yellow = ConsoleColor.Yellow;
        static ConsoleColor Green = ConsoleColor.Green;
        static ConsoleColor Blue = ConsoleColor.Blue;
        static ConsoleColor Magenta = ConsoleColor.Magenta;

        static void EnterNumbers()
        {
            Console.ForegroundColor = White;
            Console.WriteLine("Попробуй ввести не число )");
            while (true)
            {
                var input = new StringBuilder();
                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(intercept: true);

                    if (char.IsDigit(key.KeyChar))
                    {
                        input.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                    else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input.Length--;
                        Console.Write("\b \b");
                    }
                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine();

                if (int.TryParse(input.ToString(), out int result))
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                }
                break;
            }
            Console.ReadKey();
        }
        static void UpperCasing() 
        {
            string message = "";
            Console.ForegroundColor = White;
            Console.WriteLine("Введите строку");
            message = Console.ReadLine();
            var cookedMessage = new StringBuilder(message);
            for (int i = 0; i < cookedMessage.Length; i++)
            {
                if (i == 0)
                {
                    cookedMessage[i] = cookedMessage[i].ToString().ToUpper().ToCharArray()[0];
                    continue;
                }
                if (cookedMessage[i - 1] == ' ') 
                {
                    cookedMessage[i] = cookedMessage[i].ToString().ToUpper().ToCharArray()[0];
                }
            }
            Console.WriteLine(cookedMessage);
            Console.ReadKey();
        }
        static void Inverting()
        {
            if (Inverted)
            {
                White = ConsoleColor.White;
                Black = ConsoleColor.Black;
                Red = ConsoleColor.Red;
                Yellow = ConsoleColor.Yellow;
                Green = ConsoleColor.Green;
                Blue = ConsoleColor.Blue;
                Magenta = ConsoleColor.Magenta;
            }
            else
            {
                White = ConsoleColor.Black;
                Black = ConsoleColor.White;
                Red = ConsoleColor.Cyan;
                Yellow = ConsoleColor.Blue;
                Green = ConsoleColor.Magenta;
                Blue = ConsoleColor.Yellow;
                Magenta = ConsoleColor.Green;
            }
            Inverted = !Inverted;
        }
        static void Main(string[] args)
        {
            bool menuCycle = true;
            while (menuCycle)
            {
                Console.BackgroundColor = White;
                Console.ForegroundColor = Black;
                Console.WriteLine("-=-=-=-=-=-=-=-");
                Console.BackgroundColor = Black;
                Console.ForegroundColor = Red;
                Console.WriteLine("Крутые опции:");
                Console.ForegroundColor = Yellow;
                Console.WriteLine("1. Ввести цифры");
                Console.ForegroundColor = Green;
                Console.WriteLine("2. Поднимаем буквы");
                Console.ForegroundColor = Blue;
                Console.WriteLine("3. Хочешь инверсию?");
                Console.ForegroundColor = Magenta;
                Console.WriteLine("0. Выйти");
                Console.BackgroundColor = White;
                Console.ForegroundColor = Black;
                Console.WriteLine("-=-=-=-=-=-=-=-");
                Console.BackgroundColor = Black;
                Console.ForegroundColor = White;
                Console.Write("Что вы выберите? ");
                string option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1":
                        EnterNumbers();
                        break;
                    case "2":
                        UpperCasing();
                        break;
                    case "3":
                        Inverting();
                        break;
                    case "0":
                        menuCycle = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
