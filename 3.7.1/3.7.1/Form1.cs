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
            if (MessageBox.Show("Czy aby na pewno chcesz zamknąć to okno?", "Quit",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }                                                 
        }
    }
}
