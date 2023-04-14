using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitTakSis
{
    public partial class Yonetici_Panel : Form
    {
        public Yonetici_Panel()
        {
            InitializeComponent();
        }

        private void btnUyeleriGoster_Click(object sender, EventArgs e)
        {
            UyeleriGosterFrm frm = new UyeleriGosterFrm();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisCikisSaatleri frm = new GirisCikisSaatleri();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Magaza frm = new Magaza();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
