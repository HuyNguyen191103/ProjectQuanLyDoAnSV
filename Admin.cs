using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDoAnSV
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmdangkychuyennganh frmdangkychuyennganh = new Frmdangkychuyennganh();
            frmdangkychuyennganh.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formdangkygiangvien formdangkygiangvien = new Formdangkygiangvien();
            formdangkygiangvien.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formdangkysinhvien formdangkysinhvien = new Formdangkysinhvien();
            formdangkysinhvien.Show();
        }
    }
}
