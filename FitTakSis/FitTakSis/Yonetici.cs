using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTakSis
{
    class Yonetici
    {
        private string adSoyad;
        private string kullaniciAdi;
        private string sifre;

        public Yonetici(string adSoyad, string kullaniciAdi, string sifre) {
            this.adSoyad = adSoyad;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
        }

        
        public string getAdSoyad()
        {
            return this.adSoyad;
        }

        public void setAd(string adSoyad)
        {
            this.adSoyad = adSoyad;   
        }

        public string getKullaniciAdi()
        {
            return this.kullaniciAdi;
        }

        public void setKullaniciAdi(string kullaniciAdi)
        {
            this.kullaniciAdi = kullaniciAdi;
        }

        public string getSifre()
        {
            return this.sifre;
        }

        public void setSifre(string sifre)
        {
            this.sifre = sifre;
        }



    }
}
