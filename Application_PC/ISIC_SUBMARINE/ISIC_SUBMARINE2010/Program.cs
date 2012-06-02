using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//using ISIC_SUBMARINE2010.DAO;
//using ISIC_SUBMARINE.UI;

namespace ISIC_SUBMARINE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
