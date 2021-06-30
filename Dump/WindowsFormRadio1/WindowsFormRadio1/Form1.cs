using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormRadio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Blue;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Green;
        }
    }
}
