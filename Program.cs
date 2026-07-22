using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen first
            using (SplashScreenForm splash = new SplashScreenForm())
            {
                splash.ShowDialog();
            }

            // Then show main form
            Application.Run(new MainForm());
        }
    }
}


