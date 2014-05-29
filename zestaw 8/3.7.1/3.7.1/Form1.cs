using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _3._7._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Wanna quit?", "Quit",
                             MessageBoxButtons.YesNo);

            if (r == DialogResult.No)   e.Cancel = true;                                                                   
        }
    }
}
