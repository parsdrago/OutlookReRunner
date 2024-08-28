using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OutlookReRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Interval = (int)numericUpDownInterval.Value * 60 * 1000;
            timer.Start();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // check if outlook is running
            if (Process.GetProcessesByName("OUTLOOK").Length == 0)
            {
                // start outlook
                Process.Start("outlook.exe");
            }
        }
    }
}
