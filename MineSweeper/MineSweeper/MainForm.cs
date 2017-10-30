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
        int n, m, x, y, mines, width, height, col, row, numflag, time;
        Label[,] labels;
        Label flag, timer;

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            timer.Text = time.ToString();
        }

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            x = Data.Standart.X;
            y = Data.Standart.Y;
            width = Data.Size.CellWidth;
            height = Data.Size.CellHeight;
            time = 0;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            flag.Text = numflag.ToString();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            int X = e.Location.X;
            int Y = e.Location.Y;
            row = Convert.ToInt32(Math.Truncate(((Y - Data.Standart.Y) / Convert.ToDouble(height)) + 1));
            col = Convert.ToInt32(Math.Truncate(((X - Data.Standart.Y) / Convert.ToDouble(width)) + 1));
            MessageBox.Show(row.ToString() + col.ToString());
            */
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
            flag = new Label();
            numflag = mines;
            flag.Left = this.Width - 53;
            flag.Width = 35;
            flag.BorderStyle = BorderStyle.Fixed3D;
            flag.TextAlign = ContentAlignment.MiddleCenter;
            flag.Top = 0 + 10;
            flag.Text = numflag.ToString();
            flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            flag.ForeColor = Color.FromArgb(0, 255, 0, 255);
            this.Controls.Add(flag);
            timer = new Label();
            timer.Text = time.ToString();
            timer.Width = 35;
            timer.BorderStyle = BorderStyle.Fixed3D;
            timer.TextAlign = ContentAlignment.MiddleCenter;
            timer.Top = height * m - timer.Height;
            timer.Left = flag.Left;
            timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            timer.ForeColor = Color.FromArgb(0, 0, 255, 255);
            this.Controls.Add(timer);
            labels = new Label[n , m];
            Point[] minespos = new Point[mines];
            for (int i = 0; i < mines; i++) { minespos[i] = new Point(x, y); }
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Left = x;
                    labels[i, j].Top = y;
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
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
                if ((x < n - 1) && (y > 0))
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

        private Label[,] CheckEmptyCell(Label[,] a, int x, int y)
        {
            a[x, y].ForeColor = Color.Blue;
            a[x, y].Enabled = false;
            a[x, y].Text = "";
            a[x, y].BackColor = Color.LightSlateGray;
            if ((x > 0))
            {
                if ((a[x - 1, y].Text == "0") && (a[x - 1, y].Enabled == true))
                {
                    CheckEmptyCell(a, x - 1, y);
                }
                else
                {
                    a[x - 1, y].ForeColor = Color.Blue;
                    a[x - 1, y].Enabled = false;
                    a[x - 1, y].BackColor = Color.LightSlateGray;
                }
            }
            if ((x < n - 1))
            {
                if ((a[x + 1, y].Text == "0") && (a[x + 1, y].Enabled == true))
                {
                    CheckEmptyCell(a, x + 1, y);
                }
                else
                {
                    a[x + 1, y].ForeColor = Color.Blue;
                    a[x + 1, y].Enabled = false;
                    a[x + 1, y].BackColor = Color.LightSlateGray;
                }
            }
            if ((y < m - 1))
            {
                if ((a[x, y + 1].Text == "0") && (a[x, y + 1].Enabled == true))
                {
                    CheckEmptyCell(a, x, y + 1);
                }
                else
                {
                    a[x, y + 1].ForeColor = Color.Blue;
                    a[x, y + 1].Enabled = false;
                    a[x, y + 1].BackColor = Color.LightSlateGray;
                }
            }
            if ((y > 0))
            {
                if ((a[x, y - 1].Text == "0") && (a[x, y - 1].Enabled == true))
                {
                    CheckEmptyCell(a, x, y - 1);
                }
                else
                {
                    a[x, y - 1].ForeColor = Color.Blue;
                    a[x, y - 1].Enabled = false;
                    a[x, y - 1].BackColor = Color.LightSlateGray;
                }
            }
            if ((x < n - 1) && (y < m - 1))
            {
                if ((a[x + 1, y + 1].Text == "0") && (a[x + 1, y + 1].Enabled == true))
                {
                    CheckEmptyCell(a, x + 1, y + 1);
                }
                else
                {
                    a[x + 1, y + 1].ForeColor = Color.Blue;
                    a[x + 1, y + 1].Enabled = false;
                    a[x + 1, y + 1].BackColor = Color.LightSlateGray;
                }
            }
            if ((x > 0) && (y > 0))
            {
                if ((a[x - 1, y - 1].Text == "0") && (a[x - 1, y - 1].Enabled == true))
                {
                    CheckEmptyCell(a, x - 1, y - 1);
                }
                else
                {
                    a[x - 1, y - 1].ForeColor = Color.Blue;
                    a[x - 1, y - 1].Enabled = false;
                    a[x - 1, y - 1].BackColor = Color.LightSlateGray;
                }
            }
            if ((x > 0) && (y < m - 1))
            {
                if ((a[x - 1, y + 1].Text == "0") && (a[x - 1, y + 1].Enabled == true))
                {
                    CheckEmptyCell(a, x - 1, y + 1);
                }
                else
                {
                    a[x - 1, y + 1].ForeColor = Color.Blue;
                    a[x - 1, y + 1].Enabled = false;
                    a[x - 1, y + 1].BackColor = Color.LightSlateGray;
                }
            }
            if ((x < n - 1) && (y > 0))
            {
                if ((a[x + 1, y - 1].Text == "0") && (a[x + 1, y - 1].Enabled == true))
                {
                    CheckEmptyCell(a, x + 1, y - 1);
                }
                else
                {
                    a[x + 1, y - 1].ForeColor = Color.Blue;
                    a[x + 1, y - 1].Enabled = false;
                    a[x + 1, y - 1].BackColor = Color.LightSlateGray;
                }
            }
            return a;
        }

        private Bitmap MyImage;

        private void ButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(numflag < 0)
                {
                    numflag = 0;
                    MessageBox.Show("You have run out of flags!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else { numflag--; }
                //MyImage = new Bitmap("flag.png");
                //label.Image = MyImage;
            }
            else
            {
                Label label = (Label)sender;
                timer1.Enabled = true;
                label.BackColor = Color.LightSlateGray;
                int X = label.Left;
                int Y = label.Top;
                row = Convert.ToInt32(Math.Truncate(((Y - Data.Standart.Y) / Convert.ToDouble(height))));
                col = Convert.ToInt32(Math.Truncate(((X - Data.Standart.X) / Convert.ToDouble(width))));
                if (labels[row, col].Text == "0")
                {
                    CheckEmptyCell(labels, row, col);
                }
                label.ForeColor = Color.Blue;
                label.Enabled = false;
                if (label.Text == "B")
                {
                    label.BackColor = Color.Red;
                    MessageBox.Show("YOU LOSE!", "LOSER!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }
        
        private void LabelEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.Fixed3D;
        }

        private void LabelLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
