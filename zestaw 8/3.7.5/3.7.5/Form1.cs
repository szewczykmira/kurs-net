using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3._7._5
{
    public partial class Form1 : Form
    {
        string FileName;

        public Form1()
        {
            InitializeComponent();
        }

        // play
        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileName = dlg.FileName;
            }
        }
    }
}
