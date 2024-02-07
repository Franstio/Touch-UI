using System.Diagnostics;

namespace TestTCP1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            string debugLogPath = Properties.Settings.Default["DebugLogPath"].ToString() ?? "debug-log/";
            debugLogPath = debugLogPath.Contains(":/") || debugLogPath.Contains(":\\") ? debugLogPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, debugLogPath);
            if (!Directory.Exists(debugLogPath))
                Directory.CreateDirectory(debugLogPath);
            Trace.Listeners.Add(new TextWriterTraceListener(Path.Combine(debugLogPath,$"Debug-Log-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}.txt")));
            ApplicationConfiguration.Initialize();
            //            Application.Run(new CommandCenter());
            Application.Run(new MainForm());
        }
    }
}