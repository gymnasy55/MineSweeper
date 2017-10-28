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
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Data.Stage.Value = -1;
            Data.Size.Width = Convert.ToInt32(txtLenght.Text);
            Data.Size.Height = Convert.ToInt32(txtHeight.Text);
            Data.Size.Mines = Convert.ToInt32(txtMines.Text);
            OpenForm();
        }

        public void OpenForm()
        {
            MainForm form = new MainForm();
            form.ShowDialog();
            this.Close();
        }
    }
}
