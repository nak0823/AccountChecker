using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AccountChecker.Utils
{
    internal class Import
    {
        public static void LoadCombos()
        {
            string fileName;
            var x = new Thread(() =>
            {
                var openFileDialog = new OpenFileDialog();
                do
                {
                    openFileDialog.Title = "Select Combo List";
                    openFileDialog.DefaultExt = "txt";
                    openFileDialog.Filter = "Text files|*.txt";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.ShowDialog();
                    fileName = openFileDialog.FileName;
                    Globals.Tool.ComboName = openFileDialog.SafeFileName;
                } while (!File.Exists(fileName));

                Globals.Tool.Combos = new ConcurrentQueue<string>(File.ReadAllLines(fileName));
                Globals.Tool.ComboCount = Globals.Tool.Combos.Count<string>();
            });
            x.SetApartmentState(ApartmentState.STA);
            x.Start();
            x.Join();
        }

        public static void LoadProxies()
        {
            string fileName;
            var x = new Thread(() =>
            {
                var openFileDialog = new OpenFileDialog();
                do
                {
                    openFileDialog.Title = "Select Proxy List";
                    openFileDialog.DefaultExt = "txt";
                    openFileDialog.Filter = "Text files|*.txt";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.ShowDialog();
                    fileName = openFileDialog.FileName;
                    Globals.Tool.ProxyName = openFileDialog.SafeFileName;
                } while (!File.Exists(fileName));

                Globals.Tool.Proxies = new ConcurrentQueue<string>(File.ReadAllLines(fileName));
                Globals.Tool.ProxyCount = Globals.Tool.Proxies.Count<string>();
            });
            x.SetApartmentState(ApartmentState.STA);
            x.Start();
            x.Join();
        }
    }
}