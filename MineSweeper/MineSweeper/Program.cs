using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MineSweeper
{
    namespace Data
    {
        static class Stage
        {
            public static int Value { get; set; }
        }
        static class Size
        {
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Mines { get; set; }
        }
    }
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
            Application.Run(new MainMenu());
        }

    }
}
