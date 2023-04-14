using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitTakSis
{
    public partial class YagOraniHesapla : Form
    {
        public YagOraniHesapla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblE2_5.BackColor = Color.White;
            lblE10_13.BackColor = Color.White;
            lblE14_17.BackColor = Color.White;
            lblE18_24.BackColor = Color.White;
            lblE25.BackColor = Color.White;
            lblK10_13.BackColor = Color.White;
            lblK14_20.BackColor = Color.White;
            lblK21_24.BackColor = Color.White;
            lblK32.BackColor = Color.White;
            int ikisiDeSecilmemis=0;
            if(radioKadin.Checked==false&&radioErkek.Checked==false)
                ikisiDeSecilmemis=1;

            if (txtBoy.Text == "" || txtKilo.Text == "" || txtYas.Text == "" || ikisiDeSecilmemis == 1)
            {
                MessageBox.Show("Lütfen tüm değerleri eksiksiz giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double BMI, kg, height, fat, yas;
                yas = Convert.ToDouble(txtYas.Text);
                kg = Convert.ToDouble(txtKilo.Text);
                height = Convert.ToDouble(txtBoy.Text);
                height = height / 100;
                BMI = kg / (height * height);
                lblBMI.Text = BMI.ToString("N2");
                fat = (1.20 * BMI) + (0.23 * yas) - 16.2;
                lblSonuc.Text = fat.ToString("N2");
                if (radioErkek.Checked == true)
                {
                    if (fat >= 2 && fat <= 9)
                    {
                        lblE2_5.BackColor = Color.GreenYellow;
                    }
                    else if (fat >9 && fat <= 13)
                    {
                        lblE10_13.BackColor = Color.GreenYellow;
                    }
                    else if (fat > 13 && fat <= 17)
                    {
                        lblE14_17.BackColor = Color.GreenYellow;
                    }

                    else if (fat > 17 && fat <= 24)
                    {
                        lblE18_24.BackColor = Color.GreenYellow;
                    }
                    else if (fat >= 24)
                    {
                        lblE25.BackColor = Color.GreenYellow;
                    }
                }
                if (radioKadin.Checked == true)
                {
                    if (fat >= 10 && fat <= 13)
                    {
                        lblK10_13.BackColor = Color.GreenYellow;
                    }
                    else if (fat >13 && fat <= 20)
                    {
                        lblK14_20.BackColor = Color.GreenYellow;
                    }
                    else if (fat >20 && fat <= 24)
                    {
                        lblK21_24.BackColor = Color.GreenYellow;
                    }

                    else if (fat >24 && fat <= 31)
                    {
                        lblK25_31.BackColor = Color.GreenYellow;
                    }
                    else if (fat >31)
                    {
                        lblK32.BackColor = Color.GreenYellow;
                    }
                }

            }


        }
    }
}
