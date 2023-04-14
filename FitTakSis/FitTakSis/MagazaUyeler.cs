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
    public partial class MagazaUyeler : Form
    {
        public MagazaUyeler()
        {
            InitializeComponent();
        }

        private void MagazaUyeler_Load(object sender, EventArgs e)
        {

            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Magaza.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        
        }
    }
}
