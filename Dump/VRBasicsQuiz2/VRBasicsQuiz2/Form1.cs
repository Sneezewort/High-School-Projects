using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRBasicsQuiz2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor=System.Drawing.Color.Red;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor=System.Drawing.Color.Blue;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Text, 5);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Text, 12);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Text, 25);
        }
    }
}
