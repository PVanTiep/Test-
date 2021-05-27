using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_PhanVanTiep_19522347_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bt1 f = new Bt1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bt2 f = new Bt2();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bt3 f = new Bt3();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bt4 f = new Bt4();
            f.Show();
        }
    }
}
