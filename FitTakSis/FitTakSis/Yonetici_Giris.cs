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
    public partial class Yonetici_Giris : Form
    {
        public Yonetici_Giris()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            YoneticiKayit frm = new YoneticiKayit();
            frm.Show();
        }

        private void XmlVeriOku()
        {
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Yoneticiler.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            dataGridView1.DataSource = dset.Tables[0];
            reader.Close();
        }

        private void Yonetici_Giris_Load(object sender, EventArgs e)
        {
            XmlVeriOku();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlVeriOku();
            int k = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox1.Text)
                {
                    k = 1;
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == textBox2.Text)
                    {
                       Yonetici_Panel frm = new Yonetici_Panel();
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
                MessageBox.Show("Girilen kullanıcı adı ile herhangi bir kayıt bulunamadı.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
