using AccountChecker.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountChecker.Utils
{
    internal class Functions
    {
        public static string ParseToken(string content, string leftString, string rightString)
        {
            var returnThis = content.Split(new string[] { leftString }, StringSplitOptions.None)[1];
            returnThis = returnThis.Split(new string[] { rightString }, StringSplitOptions.None)[0];
            return returnThis;
        }

        public static void CalculateCPM()
        {
            for (; ; )
            {
                Globals.Tool.Cpm_Builder = 0;
                Thread.Sleep(1000);
                Globals.Tool.Cpm_Final = Globals.Tool.Cpm_Builder;
                Globals.Tool.Cpm_Final *= 60;
            }
        }

        public static void RPCUpdater()
        {
            Thread.Sleep(500);

            for (; ; )
            {
                string Status = Globals.Tool.RunningThreads > 0 ? "Running" : "Paused";
                string Details = string.Format("Hits: {0} - Free: {1} - Bads: {2} - CPM: {3} - {4}", new object[]
                {
                    Globals.Tool.Hits,
                    Globals.Tool.Frees,
                    Globals.Tool.Bads,
                    Globals.Tool.Cpm_Final,
                    Status,
                });

                string status = $"Checking: {Tool.Toolname}";
                RPC.Handler.UpdatePresence(Details, status);
                Thread.Sleep(5000);
            }
        }

        public static void PauseThreads()
        {
            while (true)
            {
                try
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.P:
                            if (Globals.Tool.RunningThreads > 0)
                            {
                                foreach (Thread tr in Globals.Tool.ActiveThreads)
                                {

                                    tr.Suspend();
                                    Globals.Tool.RunningThreads--;
                                }
                                Theme.Art.Prefix("Info", $"{Tool.Toolname} has been Paused!\n");
                            }
                            break;

                        case ConsoleKey.R:

                            if (Globals.Tool.RunningThreads < Globals.Tool.Threads && Globals.Tool.RunningThreads == 0)
                            {
                                foreach (Thread tr in Globals.Tool.ActiveThreads)
                                {
                                    tr.Resume();
                                    Globals.Tool.RunningThreads++;
                                }
                                Theme.Art.Prefix("Info", $"{Tool.Toolname} has been Resumed!\n");
                            }

                            break;
                    }
                }
                catch { }
            }
        }

        public static void UpdateTitle()
        {
            for (; ; )
            {
                Console.Title = string.Format("{0} - Hits: {1} - Free: {2} - Bads: {3} - CPM: {4} - Errors: {5} - Threads: {6}", new object[]
                {
                    Tool.Toolname,
                    Globals.Tool.Hits,
                    Globals.Tool.Frees,
                    Globals.Tool.Bads,
                    Globals.Tool.Cpm_Final,
                    Globals.Tool.Errors,
                    Globals.Tool.RunningThreads
                });
            }
        }


    }
}
