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
    public partial class UyeleriGosterFrm : Form
    {
        public UyeleriGosterFrm()
        {
            InitializeComponent();
        }

        private void btnXMLOlusuturucu_Click(object sender, EventArgs e)
        {
            XmlTextWriter dosya = new XmlTextWriter(@"Uyeler.xml", Encoding.UTF8);

            dosya.Formatting = Formatting.Indented;
            dosya.WriteStartDocument();
            dosya.WriteStartElement("Uyeler");
            dosya.WriteEndElement();
            dosya.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aynisiVarMi = 0;
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtKullaniciAdi.Text)
                    aynisiVarMi = 1;
            }

            if (aynisiVarMi == 0)
            {
                string sCinsiyet;
                string sSeviye = "";

                if (radioBaslangic.Checked == true)
                    sSeviye = "Başlangıç";
                else if (radioOrta.Checked == true)
                    sSeviye = "Orta";
                else if (radioGelismis.Checked == true)
                    sSeviye = "Gelişmiş";


                if (radioErkek.Checked == true)
                    sCinsiyet = "Erkek";
                else if (radioKadin.Checked == true)
                    sCinsiyet = "Kadın";
                else
                    sCinsiyet = "Özel";

                Uye uye = new Uye(txtAdSoyad.Text, txtSifre.Text, txtKullaniciAdi.Text, maskedBaslangic.Text, maskedBitis.Text, Convert.ToDouble(txtKilo.Text), Convert.ToDouble(txtBoy.Text), "", sCinsiyet, maskedTelefon.Text, Convert.ToDouble(txtYas.Text), sSeviye);

                XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
                XElement rootelement = xdosya.Root;
                XElement element = new XElement("Uye");
                XElement adSoyad = new XElement("adSoyad", uye.getAdSoyad());
                XElement kullaniciAdi = new XElement("kullaniciAdi", uye.getKullaniciAdi());
                XElement sifre = new XElement("sifre", uye.getSifre());
                XElement baslangicTarihi = new XElement("baslangicTarihi", uye.getBaslangicTarihi());
                XElement bitisTarihi = new XElement("bitisTarihi", uye.getBitisTarihi());
                XElement kilo = new XElement("kilo", uye.getKilo().ToString());
                XElement boy = new XElement("boy", uye.getBoy().ToString());
                XElement antreman = new XElement("antreman", uye.getAntremanlar());
                XElement cinsiyet = new XElement("cinsiyet", uye.getCinsiyet());
                XElement telefon = new XElement("telefon", uye.getTelefon());
                XElement yas = new XElement("yas", uye.getYas().ToString());
                XElement seviye = new XElement("seviye", uye.getSeviye());

                element.Add(adSoyad, kullaniciAdi, sifre, baslangicTarihi, bitisTarihi, kilo, boy, antreman, yas, telefon, cinsiyet, seviye);
                rootelement.Add(element);
                xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
                MessageBox.Show("Kayıt İşlemi Başarılı");
                XmlVeriOku();
            }
            else
            {
                MessageBox.Show("Aynı kullanıcı adına sahip başka bir kullanıcı var. Lütfen farklı bir kullanıcı adıyla tekrar deneyiniz.");
            }
           
        }

        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }

        private void UyeleriGosterFrm_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             string sSeviye="";
            if (radioBaslangic.Checked == true)
                sSeviye = "Başlangıç";
            else if (radioOrta.Checked == true)
                sSeviye = "Orta";
            else if (radioGelismis.Checked == true)
                sSeviye = "Gelişmiş";

            XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
            XElement element = xdosya.Element("Uyeler").Elements("Uye").FirstOrDefault(x => x.Element("kullaniciAdi").Value == txtKullaniciAdi.Text);

            if (element != null)
            {
                element.SetElementValue("adSoyad", txtAdSoyad.Text);
                element.SetElementValue("sifre", txtSifre.Text);
                element.SetElementValue("baslangicTarihi", maskedBaslangic.Text);
                element.SetElementValue("bitisTarihi", maskedBitis.Text);
                element.SetElementValue("kilo", txtKilo.Text);
                element.SetElementValue("boy", txtBoy.Text);
               // element.SetElementValue("antreman", txtReturns.Text);
               
                //element.SetElementValue("cinsiyet", .Text);
                element.SetElementValue("telefon", maskedTelefon.Text);
                element.SetElementValue("yas", txtYas.Text);
                element.SetElementValue("seviye", sSeviye);

                xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
                MessageBox.Show("Güncelleme işlemi başarılı...");
                XmlVeriOku();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtAdSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtKullaniciAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                maskedBaslangic.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                maskedBitis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtKilo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBoy.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtYas.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                maskedTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                if (cinsiyet == "Erkek")
                    radioErkek.Checked = true;
                else
                    radioKadin.Checked = true;
                string seviye = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

                if (seviye == "Baslangıç")
                    radioBaslangic.Checked = true;
                if (seviye == "Orta")
                    radioOrta.Checked = true;
                if (seviye == "Gelişmiş")
                    radioGelismis.Checked = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtAdSoyad.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            radioErkek.Checked = false;
            radioKadin.Checked = false;
            txtKilo.Text = "";
            txtBoy.Text = "";
            txtYas.Text = "";
            maskedTelefon.Text = "";
            maskedBaslangic.Text = "";
            maskedBitis.Text = "";
            radioBaslangic.Checked = false;
            radioOrta.Checked = false;
            radioGelismis.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
            xdosya.Root.Elements().Where(x => x.Element("kullaniciAdi").Value == txtKullaniciAdi.Text).Remove();
            xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
            MessageBox.Show("Silme işlemi başarılı...");
            XmlVeriOku();
        }
    }
}
