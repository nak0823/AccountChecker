using System.Drawing;
using AccountChecker.Globals;
using Console = Colorful.Console;

namespace AccountChecker.Theme
{
    internal class Art
    {
        private static readonly string Art1 = " ██████╗██╗  ██╗███████╗ ██████╗██╗  ██╗███████╗██████╗ ";
        private static readonly string Art2 = "██╔════╝██║  ██║██╔════╝██╔════╝██║ ██╔╝██╔════╝██╔══██╗";
        private static readonly string Art3 = "██║     ███████║█████╗  ██║     █████╔╝ █████╗  ██████╔╝";
        private static readonly string Art4 = "██║     ██╔══██║██╔══╝  ██║     ██╔═██╗ ██╔══╝  ██╔══██╗";
        private static readonly string Art5 = "╚██████╗██║  ██║███████╗╚██████╗██║  ██╗███████╗██║  ██║";
        private static readonly string Art6 = " ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝";

        private static readonly string Login = $"{Tool.Toolname} ~ {Tool.Version} ~ Authenticating User";
        private static readonly string Credits = $"{Tool.Toolname} ~ {Tool.Version} ~ Developed by {Tool.Author}";

        public static readonly Color Fade1 = ColorTranslator.FromHtml("#FF5343");
        public static readonly Color Fade2 = ColorTranslator.FromHtml("#FF5F50");
        public static readonly Color Fade3 = ColorTranslator.FromHtml("#FF6B5E");
        public static readonly Color Fade4 = ColorTranslator.FromHtml("#FF786B");
        public static readonly Color Fade5 = ColorTranslator.FromHtml("#FF8479");
        public static readonly Color Fade6 = ColorTranslator.FromHtml("#FF9086");

        public static readonly Color Primary = Fade1;
        public static readonly Color Secundary = Fade6;

        public static void Display()
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(Console.WindowWidth / 2 - Art1.Length / 2, 1);
            Console.WriteLine(Art1, Fade1);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Art2.Length / 2, 2);
            Console.WriteLine(Art2, Fade2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Art3.Length / 2, 3);
            Console.WriteLine(Art3, Fade3);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Art4.Length / 2, 4);
            Console.WriteLine(Art4, Fade4);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Art5.Length / 2, 5);
            Console.WriteLine(Art5, Fade5);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Art6.Length / 2, 6);
            Console.WriteLine(Art6, Fade6);

            if (Globals.Tool.IsLoggedIn == false)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - Login.Length / 2, 7);
                WriteCredits();
            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - Credits.Length / 2, 7);
                WriteCredits();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteCredits()
        {
            Console.Write(Tool.Toolname, Primary);
            Console.Write(" ~ ", Secundary);
            Console.Write(Tool.Version, Primary);
            Console.Write(" ~ ", Secundary);
            Console.Write("Developed by ", Primary);
            Console.Write(Tool.Author, Primary);
        }

        public static void WriteAuth()
        {
            Console.Write(Tool.Toolname, Primary);
            Console.Write(" ~ ", Secundary);
            Console.Write(Tool.Version, Primary);
            Console.Write(" ~ ", Secundary);
            Console.Write("Authenticating User", Primary);
        }

        public static void Prefix(string prefix, string content)
        {
            Console.Write(" [", Primary);
            Console.Write(prefix, Secundary);
            Console.Write("] ", Primary);
            Console.Write(content, Secundary);
        }
    }
}