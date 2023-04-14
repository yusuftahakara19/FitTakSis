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
    public partial class GirisCikisSaatleri : Form
    {
        public GirisCikisSaatleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\UyeGirisleri.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }

        private void GirisCikisSaatleri_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XmlTextWriter dosya = new XmlTextWriter(@"UyeGirisleri.xml", Encoding.UTF8);

            dosya.Formatting = Formatting.Indented;
            dosya.WriteStartDocument();
            dosya.WriteStartElement("UyeGirisleri");
            dosya.WriteEndElement();
            dosya.Close();
        }
    }
}
