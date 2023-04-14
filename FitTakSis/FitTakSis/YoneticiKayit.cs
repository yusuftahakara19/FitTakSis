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
    public partial class YoneticiKayit : Form
    {
        public YoneticiKayit()
        {
            InitializeComponent();
        }

        private void btnXMLOlusuturucu_Click(object sender, EventArgs e)
        {
            XmlTextWriter dosya = new XmlTextWriter(@"Yoneticiler.xml", Encoding.UTF8);

            dosya.Formatting = Formatting.Indented;
            dosya.WriteStartDocument();
            dosya.WriteStartElement("Yoneticiler");
            dosya.WriteEndElement();
            dosya.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int ayniVarMi =0;
           for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtKullaniciAdi.Text)
                    ayniVarMi = 1;
            }

           if (ayniVarMi == 0)
           {

               Yonetici yonetici = new Yonetici(txtAdSoyad.Text, txtKullaniciAdi.Text, txtSifre.Text);

               XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Yoneticiler.xml");
               XElement rootelement = xdosya.Root;
               XElement element = new XElement("Yonetici");
               XElement adSoyad = new XElement("adSoyad", yonetici.getAdSoyad());
               XElement kullaniciAdi = new XElement("kullaniciAdi", yonetici.getKullaniciAdi());
               XElement sifre = new XElement("sifre", yonetici.getSifre());
               element.Add(adSoyad, kullaniciAdi, sifre);
               rootelement.Add(element);
               xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Yoneticiler.xml");
               MessageBox.Show("Kayıt Başarılı");
               XmlVeriOku();
           }
           else
           {
               MessageBox.Show("Aynı kullanıcı adına sahip bir başka kullanıcı bulundu. Lütfen farklı bir kullanıcı adı ile tekrar deneyiniz.");
           }

        }

        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Yoneticiler.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
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

        private void YoneticiKayit_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtKullaniciAdi.Text != "" && txtSifre.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtKullaniciAdi.Text != "" && txtSifre.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtKullaniciAdi.Text != "" && txtSifre.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
