using AccountChecker.Globals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountChecker.Utils
{
    internal class Export
    {
        public static string time = DateTime.Now.ToString("- h.mm tt");
        public static string day = DateTime.Now.ToString("dddd d, MMMM yyyy");

        public static void Hit(string[] ModuleInfo, string Hit)
        {
            Globals.Tool.Hits++;
            Globals.Tool.Checks++;
            Globals.Tool.Cpm_Builder++;

            Theme.Art.Prefix("Hit", Hit + $" -> {ModuleInfo[0]}\n");

            ExportLine(ModuleInfo[1], ModuleInfo[0], Hit, "Hits");
        }

        public static void Free(string[] ModuleInfo, string Free)
        {
            Globals.Tool.Frees++;
            Globals.Tool.Checks++;
            Globals.Tool.Cpm_Builder++;

            Globals.Tool.PrintFrees = false;
            Globals.Tool.SaveFrees = true;

            if (Globals.Tool.PrintFrees == true)
            {
                Theme.Art.Prefix("Free", Free + $" -> {ModuleInfo[0]}\n");
            }

            if (Globals.Tool.SaveFrees == true)
            {
                ExportLine(ModuleInfo[1], ModuleInfo[0], Free, "Frees");
            }
        }

        public static void Bad(string[] ModuleInfo, string Bad)
        {
            Globals.Tool.Bads++;
            Globals.Tool.Checks++;
            Globals.Tool.Cpm_Builder++;

            if (Globals.Tool.PrintBads == true)
            {
                //Theme.Art.Prefix("Bad", Bad + $" -> {ModuleInfo[0]}\n");
            }

            if (Globals.Tool.SaveBads == true)
            {
                //ExportLine(ModuleInfo[1], ModuleInfo[0], Bad, "Bads");
            }
        }

        public static void Error(string[] ModuleInfo, string Error)
        {
            Globals.Tool.Errors++;

            if (Globals.Tool.PrintErrors == true)
            {
                //Theme.Art.Prefix("Error", Error + $" -> {ModuleInfo[0]}\n");
            }

            if (Globals.Tool.ErrorLog == true)
            {
                //(ModuleInfo[1], ModuleInfo[0], Error, "Errors");
            }
        }

        public static void ExportLine(string ModuleCat, string Module, string Line, string Type)
        {
            var Comboname = Globals.Tool.ComboName.Replace(".txt", string.Empty);
            var SelectedModCount = 1;

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + $"{Tool.Toolname}\\{day}\\{Comboname} [{SelectedModCount}] {time}\\{Module}"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + $"{Tool.Toolname}\\{day}\\{Comboname} [{SelectedModCount}] {time}\\{Module}");

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"{Tool.Toolname}\\{day}\\{Comboname} [{SelectedModCount}] {time}\\{Module}\\{Module}-{Type}.txt"))
            {
                var CreateExport = File.Create(AppDomain.CurrentDomain.BaseDirectory + $"{Tool.Toolname}\\{day}\\{Comboname} [{SelectedModCount}] {time}\\{Module}\\{Module}-{Type}.txt");
                CreateExport.Close();
            }

            object locked = new object();
            lock (locked)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + $"{Tool.Toolname}\\{day}\\{Comboname} [{SelectedModCount}] {time}\\{Module}\\{Module}-{Type}.txt", Line + Environment.NewLine);
            }
        }

    }
}
