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
    public partial class EgzersizYapFrm : Form
    {
        public EgzersizYapFrm()
        {
            InitializeComponent();
        }


        public string seviye;
        public string kullaniciAdi;
        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }
        private void EgzersizYapFrm_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
            label1.Text = "Seviye : " + seviye;
            if (seviye == "Başlangıç")
            {
                listBox1.Items.Add("Ayakta Bisiklet Crunch Hareketi x20");
                listBox1.Items.Add("Karın Crunch Hareketi x10");
                listBox1.Items.Add("Plank 00:30");
                listBox1.Items.Add("Köprü Hareketi x20");
                listBox1.Items.Add("Yan Köprü Sağ x20");
                listBox1.Items.Add("Yan Köprü Sol x20");
                listBox1.Items.Add("Bisiklet Crunch Hareketi x16");
                listBox1.Items.Add("Yatık Yan Karın Kası Dönüşü x20");
                listBox1.Items.Add("T plank Hareketi sağ");
                listBox1.Items.Add("T plank Hareketi sol");
                listBox1.Items.Add("Kobra Gerilmesi 00:30");
                lblKalori.Text = "195 Kcal";
            }
            if (seviye == "Orta")
            {
                listBox1.Items.Add("Ayakta Bisiklet Crunch Hareketi x20");
                listBox1.Items.Add("Karın Crunch Hareketi x20");
                listBox1.Items.Add("Plank 00:45");
                listBox1.Items.Add("Köprü Hareketi x30");
                listBox1.Items.Add("Yan Köprü Sağ x30");
                listBox1.Items.Add("Yan Köprü Sol x30");
                listBox1.Items.Add("Bisiklet Crunch Hareketi x32");
                listBox1.Items.Add("Yatık Yan Karın Kası Dönüşü x30");
                listBox1.Items.Add("T plank Hareketi sağ");
                listBox1.Items.Add("T plank Hareketi sol");
                listBox1.Items.Add("Kobra Gerilmesi 00:45");
                lblKalori.Text = "500 Kcal";
            }
            if (seviye == "Gelişmiş")
            {
                listBox1.Items.Add("Ayakta Bisiklet Crunch Hareketi x40");
                listBox1.Items.Add("Karın Crunch Hareketi x40");
                listBox1.Items.Add("Plank 01:00");
                listBox1.Items.Add("Köprü Hareketi x40");
                listBox1.Items.Add("Yan Köprü Sağ x40");
                listBox1.Items.Add("Yan Köprü Sol x40");
                listBox1.Items.Add("Bisiklet Crunch Hareketi x30");
                listBox1.Items.Add("Yatık Yan Karın Kası Dönüşü x30");
                listBox1.Items.Add("T plank Hareketi sağ");
                listBox1.Items.Add("T plank Hareketi sol");
                listBox1.Items.Add("Kobra Gerilmesi 02:00");
                lblKalori.Text = "750 Kcal";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string today = DateTime.UtcNow.ToString("dd.MM.yyyy");
            string antreman="";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == kullaniciAdi)
                {
                    antreman = dataGridView1.Rows[i].Cells[7].Value.ToString();
                }
            }
            XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
            XElement element = xdosya.Element("Uyeler").Elements("Uye").FirstOrDefault(x => x.Element("kullaniciAdi").Value == kullaniciAdi);

            if (element != null)
            {
            
           element.SetElementValue("antreman", antreman + " "+today+" ("+lblKalori.Text+")"+" - ");

                xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Uyeler.xml");
                XmlVeriOku();
            }
            MessageBox.Show("Tebrikler... Antreman kaydı başarılı.");
        }
    }
}
