using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FitTakSis
{
    public partial class UyePanel : Form
    {
        public UyePanel()
        {
            InitializeComponent();
        }

        public string seviye;
        public string kullaniciAd;
        private void UyePanel_Load(object sender, EventArgs e)
        {
            lblAd.Text = kullaniciAd;
            lblSeviye.Text ="Seviye : "+ seviye;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EgzersizYapFrm frm = new EgzersizYapFrm();
            frm.seviye = seviye;
            frm.kullaniciAdi = kullaniciAd;
            frm.Show();
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YagOraniHesapla frm = new YagOraniHesapla();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MagazaUyeler frm = new MagazaUyeler();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GecmisAntremanlaraGozat frm = new GecmisAntremanlaraGozat();
            frm.kullaniciAdi = kullaniciAd;
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
