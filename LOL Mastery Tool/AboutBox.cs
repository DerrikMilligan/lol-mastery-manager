using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOL_Mastery_Tool
{
    public partial class AboutBox : Form
    {
        static AboutBox aboutBox;

        public AboutBox()
        {
            InitializeComponent();
        }

        public static void showBox()
        {
            aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            aboutBox.Dispose();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            aboutBox.Dispose();
        }
    }
}
