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
            Label[,] labels = new Label[n , m];
            Point[] minespos = new Point[mines];
            for (int i = 0; i < mines; i++) { minespos[i] = new Point(x, y); }
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    labels[i, j] = new Label();
                    //buttons[i, j].MouseClick += new EventHandler(button1_MouseClick);
                    //buttons[i, j].MouseClick += button1_MouseClick;
                    labels[i, j].Left = x;
                    labels[i, j].Top = y;
                    labels[i, j].Width = width;
                    labels[i, j].Height = height;
                    labels[i, j].MouseClick += ButtonClick;
                    labels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    labels[i, j].MouseEnter += new EventHandler(LabelEnter);
                    labels[i, j].AutoSize = false;
                    labels[i, j].MouseLeave += new EventHandler(LabelLeave);
                    labels[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    labels[i, j].BackColor = Color.LightGray;
                    labels[i, j].ForeColor = Color.LightGray;
                    labels[i, j].FlatStyle = FlatStyle.Popup;
                    labels[i, j].Text = "0";
                    this.Controls.Add(labels[i, j]);
                    x += width + 1;
                }
                x = Data.Standart.X;
                y += height + 1;
            }
            y = Data.Standart.Y;
            TakeBombs(labels, n, m, minespos);
            CheckBombs(labels, minespos);
        }

        private Label[,] CheckBombs(Label[,] a, Point[] minespos)
        {
            for(int i=0; i<mines;i++)
            {
                int x = minespos[i].X;
                int y = minespos[i].Y;
                if ((x > 0))
                {
                    int e = Convert.ToInt32(a[x - 1, y].Text) ;
                    e++;
                    a[x - 1, y].Text = Convert.ToString(e);
                }
                if ((x < n-1))
                {
                    int e = Convert.ToInt32(a[x + 1, y].Text) ;
                    e++;
                    a[x + 1, y].Text = Convert.ToString(e);
                }
                if ((y < m - 1))
                {
                    int e = Convert.ToInt32(a[x, y + 1].Text) ;
                    e++;
                    a[x, y+1].Text = Convert.ToString(e);
                }
                if ((y > 0))
                {
                    int e = Convert.ToInt32(a[x, y - 1].Text) ;
                    e++;
                    a[x , y-1].Text = Convert.ToString(e);
                }
                if ((x <n-1) && (y < m-1) )
                {
                    int e = Convert.ToInt32(a[x + 1, y + 1].Text) ;
                    e++;
                    a[x+1 , y + 1].Text = Convert.ToString(e);
                }
                if ((x > 0)  && (y > 0) )
                {
                    int e = Convert.ToInt32(a[x - 1, y - 1].Text);
                    e++;
                    a[x - 1, y - 1].Text = Convert.ToString(e);
                }
                if ((x > 0) && (y < m-1))
                {
                    int e = Convert.ToInt32(a[x - 1, y + 1].Text);
                    e++;
                    a[x - 1, y + 1].Text = Convert.ToString(e);
                }
                if ((x <n-1) && (y >0))
                {
                    int e = Convert.ToInt32(a[x + 1, y - 1].Text);
                    e++;
                    a[x + 1, y - 1].Text = Convert.ToString(e);
                }
            }
            for (int i = 0; i < mines; i++)
            {
                int x = minespos[i].X;
                int y = minespos[i].Y;

                a[x, y].Text = "B";
            }
            return a;
        }
        private Label[,] TakeBombs(Label[,] a, int n, int m, Point[] minespos)
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
                while (a[q, w].Text == "-100");
                minespos[i] = new Point(q, w);
                a[q, w].Text = "-100";
            }
            return a;
        }
        private Bitmap MyImage;
        private void ButtonClick(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("бла-бла-бла!!!2");
                //MyImage = new Bitmap("flag.png");
                //label.Image = MyImage;

            }
            else
            {
                MessageBox.Show("бла-бла-бла!!!");
                label.ForeColor = Color.Blue;
                label.Enabled = false;
                if (label.Text == "B")
                {
                    MessageBox.Show("Вы проиграли!");
                    this.Close();
                }

            }
        }
        
        private void LabelEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BorderStyle = BorderStyle.Fixed3D;
        }

        private void LabelLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
