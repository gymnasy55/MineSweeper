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
        Random rnd;
        int n, m, x, y, mines, width, height;
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            x = Data.Standart.X;
            y = Data.Standart.Y;
            width = Data.Size.CellWidth;
            height = Data.Size.CellHeight;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            switch(Data.Stage.Value)
            {
                case -1:
                    n = Data.Size.Width;
                    m = Data.Size.Height;
                    mines = Data.Size.Mines;
                    break;
                case 0:
                    n = Data.EasyField.Width;
                    m = Data.EasyField.Height;
                    mines = Data.EasyField.Mines;
                    break;
                case 1:
                    n = Data.MediumField.Width;
                    m = Data.MediumField.Height;
                    mines = Data.MediumField.Mines;
                    break;
                case 2:
                    n = Data.HardField.Width;
                    m = Data.HardField.Height;
                    mines = Data.HardField.Mines;
                    break;
            }
            this.Width = m * (width + 8);
            this.Height = n * (height + 8);
            Button[,] buttons = new Button[n , m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Left = x;
                    buttons[i, j].Top = y;
                    buttons[i, j].Width = width;
                    buttons[i, j].Height = height;
                    buttons[i, j].Click += new EventHandler(ButtonClick);
                    buttons[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif",
                                                                                        16F,
                                                                                        System.Drawing.FontStyle.Bold,
                                                                                        System.Drawing.GraphicsUnit.Point,
                                                                                        ((byte)(204)));
                    buttons[i, j].BackColor = Color.LightGray;
                    buttons[i, j].ForeColor = Color.LightGray;
                    buttons[i, j].Text = "1";
                    buttons[i, j].FlatStyle = FlatStyle.Popup;
                    this.Controls.Add(buttons[i, j]);
                    x += width + 5;
                }
                x = Data.Standart.X;
                y += height + 5;
            }
            y = Data.Standart.Y;
            TakeBombs(buttons, n, m);
        }

        private Button[,] TakeBombs(Button[,] a, int n, int m)
        {
            
            
                for(int i=0;i<mines;i++)
                {
                    int q;
                    int w;

                    do
                    {
                        q = rnd.Next(0, n);
                        w = rnd.Next(0, m);
                    }
                    while (a[q, w].Text == "B");
                    
                    a[q, w].Text = "B";
                }
            return a;
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Blue;
            button.Enabled = false;
            if (button.Text == "B")
            {
                MessageBox.Show("Вы проиграли!");
                this.Close();
            }
        }
    }
}
