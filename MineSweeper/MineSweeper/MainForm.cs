using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        int n, m, x, y, mines, width, height, standart;
        public MainForm()
        {
            InitializeComponent();
            standart = 2;
            x = standart;
            y = standart;
            width = 40;
            height = 40;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            switch(Data.Stage.Value)
            {
                case -1:
                    n = Data.Size.Height;
                    m = Data.Size.Width;
                    mines = Data.Size.Mines;
                    break;
                case 0:
                    n = 9;
                    m = 9;
                    mines = 10;
                    break;
                case 1:
                    n = 16;
                    m = 16;
                    mines = 40;
                    break;
                case 2:
                    n = 16;
                    m = 30;
                    mines = 100;
                    break;
            }
            this.Width = m * (width + 8);
            this.Height = n * (height + 8);
            Button[] buttons = new Button[n * m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    buttons[i * j] = new Button();
                    buttons[i * j].Left = x;
                    buttons[i * j].Top = y;
                    buttons[i * j].Width = width;
                    buttons[i * j].Height = height;
                    buttons[i * j].Click += new EventHandler(ButtonClick);
                    buttons[i * j].Font = new System.Drawing.Font("Microsoft Sans Serif",
                                                                                        16F,
                                                                                        System.Drawing.FontStyle.Bold,
                                                                                        System.Drawing.GraphicsUnit.Point,
                                                                                        ((byte)(204)));
                    this.Controls.Add(buttons[i * j]);
                    x += width + 5;
                }
                x = standart;
                y += height + 5;
            }
            y = standart;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "1";
            button.Enabled = false;
        }
    }
}
