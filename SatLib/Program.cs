using AccountChecker.Globals;

namespace AccountChecker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RPC.Handler.Initialize($"Initializing {Tool.Toolname}", "Initializing");
            Menu.LoginMenu();
        }
    }
}