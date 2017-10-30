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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Data.Stage.Value = 0;
            OpenForm();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Data.Stage.Value = 1;
            OpenForm();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Data.Stage.Value = 2;
            OpenForm();
        }
        void OpenForm()
        {
            MainForm form = new MainForm();
            form.ShowDialog();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            CustomForm form = new CustomForm();
            form.ShowDialog();
        }
    }
}
