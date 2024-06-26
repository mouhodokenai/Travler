using System;
using System.Windows.Forms;
using NLog;

namespace WinFormsApp3
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main()
        {
            // Ensure NLog configuration is loaded
            LogManager.LoadConfiguration("NLog.config");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.Info("Приложение запущено");
            Application.Run(new Welcome());
        }
    }
}
