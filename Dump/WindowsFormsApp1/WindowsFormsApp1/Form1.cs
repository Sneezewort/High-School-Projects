using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Stopwatch sw = new Stopwatch();
        private Boolean swStatus = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Boom!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Loom";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Doom";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (swStatus == false)
                sw.Start();
            else if (swStatus == true)
            {
                sw.Stop();
                var ts = sw.Elapsed;
                String eTime = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds / 10}";
                label2.Text = eTime;
            }
        }
    }
}
