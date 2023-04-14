using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FitTakSis
{
    public partial class Uye_Girisi : Form
    {
        public Uye_Girisi()
        {
            InitializeComponent();
        }
        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }
        private void Uye_Girisi_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        { 
            XmlVeriOku();
            int k = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1 ; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtKullaniciAdi.Text)
                {
                    k = 1;
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == txtSifre.Text)
                    {
                  
                        DateTime now = DateTime.Now;
                        UyePanel frm = new UyePanel();
                        frm.seviye = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\UyeGirisleri.xml");
                        XElement rootelement = xdosya.Root;
                        XElement element = new XElement("Giris");
                        XElement kullaniciAdi = new XElement("Kullanıcı_Adi", txtKullaniciAdi.Text);
                        XElement girisZamani = new XElement("Giris_Zamani", now.ToString("F"));
                        element.Add(kullaniciAdi,girisZamani);
                        rootelement.Add(element);
                        xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\UyeGirisleri.xml");
                        frm.kullaniciAd = txtKullaniciAdi.Text;
                        txtKullaniciAdi.Text = "";
                        txtSifre.Text = "";
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Şifre yanlış. Lütfen tekrar deneyiniz...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            if (k != 1)
                MessageBox.Show("Girilen kullanıcı adı ile herhangi bir kayıt bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
