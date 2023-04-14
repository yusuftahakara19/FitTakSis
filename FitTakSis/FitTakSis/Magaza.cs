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
    public partial class Magaza : Form
    {
        public Magaza()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextWriter dosya = new XmlTextWriter(@"Magaza.xml", Encoding.UTF8);

            dosya.Formatting = Formatting.Indented;
            dosya.WriteStartDocument();
            dosya.WriteStartElement("Urunler");
            dosya.WriteEndElement();
            dosya.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aynisiVarMi = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == textBox1.Text)
                    aynisiVarMi = 1;
            }

            if (aynisiVarMi == 0)
            {
          

 
                XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
                XElement rootelement = xdosya.Root;
                XElement element = new XElement("Urun");
                XElement urun = new XElement("urun_Adi", textBox1.Text);
                XElement fiyat = new XElement("fiyat", textBox2.Text+" TL");
                element.Add(urun,fiyat);
                rootelement.Add(element);
                xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
                MessageBox.Show("Ekleme İşlemi Başarılı");
                XmlVeriOku();
            }
            else
            {
                MessageBox.Show("Aynı ürün adına sahip başka bir ürün var. Lütfen farklı bir ürün adıyla tekrar deneyiniz.");
            }
        }
        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
            XElement element = xdosya.Element("Urunler").Elements("Urun").FirstOrDefault(x => x.Element("urun_Adi").Value == textBox1.Text);

            if (element != null)
            {
                element.SetElementValue("urun_Adi", textBox1.Text);
                element.SetElementValue("fiyat", textBox2.Text);
                xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
                MessageBox.Show("Güncelleme işlemi başarılı...");
                XmlVeriOku();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument xdosya = XDocument.Load(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
            xdosya.Root.Elements().Where(x => x.Element("urun_Adi").Value == textBox1.Text).Remove();
            xdosya.Save(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml");
            MessageBox.Show("Silme işlemi başarılı...");
            XmlVeriOku();
        }

        private void Magaza_Load(object sender, EventArgs e)
        {
           XmlVeriOku();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
