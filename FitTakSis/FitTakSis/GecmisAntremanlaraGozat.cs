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

namespace FitTakSis
{
    public partial class GecmisAntremanlaraGozat : Form
    {
        public GecmisAntremanlaraGozat()
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

        public string kullaniciAdi;

        private void GecmisAntremanlaraGozat_Load(object sender, EventArgs e)
        {
              XmlVeriOku();
              string[] kelimeler;
            string metin ="";
              for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
              {
                  if (dataGridView1.Rows[i].Cells[1].Value.ToString() == kullaniciAdi)
                  {
                     metin = dataGridView1.Rows[i].Cells[7].Value.ToString();

                      kelimeler = metin.Split('-');

                      for (int j = 0; j < kelimeler.Length; j++)
                      {
                          listBox1.Items.Add(kelimeler[j]);
                      }
                  }
              }
        }
    }
}
