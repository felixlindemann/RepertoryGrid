using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepertoryGridGUI.ufos;

namespace RepertoryGridGUI
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormProject());
            //Application.Run(new FormTest());
        }
    }
}
