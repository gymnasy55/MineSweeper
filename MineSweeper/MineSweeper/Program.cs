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
            public static int CellWidth { get; set; }
            public static int CellHeight { get; set; }
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Mines { get; set; }
        }
        static class Standart
        {
            public static int X { get; set; }
            public static int Y { get; set; }
        }
        static class EasyField
        {
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Mines { get; set; }
        }
        static class MediumField
        {
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Mines { get; set; }
        }
        static class HardField
        {
            public static int Width { get; set; }
            public static int Height { get; set; }
            public static int Mines { get; set; }
        }
        static class CustomField
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
            Data.Size.CellHeight = 40;
            Data.Size.CellWidth = 40;
            Data.Standart.X = 2;
            Data.Standart.Y = 2;
            Data.EasyField.Width = 9;
            Data.EasyField.Height = 9;
            Data.EasyField.Mines = 10;
            Data.MediumField.Width = 16;
            Data.MediumField.Height = 16;
            Data.MediumField.Mines = 10;
            Data.HardField.Width = 16;
            Data.HardField.Height = 30;
            Data.HardField.Mines = 10;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }

    }
}
