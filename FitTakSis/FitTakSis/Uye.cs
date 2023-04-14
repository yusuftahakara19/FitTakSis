using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTakSis
{
    class Uye
    {
        private string adSoyad;
        private string sifre;
        private string kullaniciAdi;
        private string baslangicTarihi;
        private string bitisTarihi;
        private double kilo;
        private double boy;
        private string antremanlar;
        private string cinsiyet;
        private string telefon;
        private double yas;
        private string seviye;


        public Uye(string adSoyad, string sifre, string kullaniciAdi, string baslangicTarihi, string bitisTarihi, double kilo, double boy, string antremanlar,string cinsiyet,string telefon,double yas,string seviye)
        {
            this.adSoyad = adSoyad;
            this.sifre = sifre;
            this.kullaniciAdi = kullaniciAdi;
            this.baslangicTarihi = baslangicTarihi;
            this.bitisTarihi = bitisTarihi;
            this.kilo = kilo;
            this.boy = boy;
            this.antremanlar = antremanlar;
            this.cinsiyet = cinsiyet;
            this.telefon = telefon;
            this.yas = yas;
            this.seviye = seviye;
        }
        public string getSeviye()
        {
            return this.seviye;
        }

        public void setSeviye(string seviye)
        {
            this.seviye = seviye;
        }

        public string getCinsiyet()
        {
            return this.cinsiyet;
        }

        public void setCinsiyet(string cinsiyet)
        {
            this.cinsiyet = cinsiyet;
        }

        public string getTelefon()
        {
            return this.telefon;
        }

        public void setTelefon(string telefon)
        {
            this.telefon = telefon;
        }

        public string getAntremanlar()
        {
            return this.antremanlar;
        }

        public void setAntremanlar(string antremanlar)
        {
            this.antremanlar = antremanlar;
        }


        public double getYas()
        {
            return this.yas;
        }
        public void setYas(double yas)
        {
            this.yas = yas;
        }


        public double getKilo()
        {
            return this.kilo;
        }
        public void setKilo(double kilo)
        {
            this.kilo = kilo;
        }

        public double getBoy()
        {
            return this.boy;
        }
        public void setBoy(double boy)
        {
            this.boy = boy;
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

        public string getBaslangicTarihi()
        {
            return this.baslangicTarihi;
        }

        public void setBaslangicTarihi(string baslangicTarihi)
        {
            this.baslangicTarihi = baslangicTarihi;
        }

        public string getBitisTarihi()
        {
            return this.bitisTarihi;
        }

        public void setBitisTarihi(string bitisTarihi)
        {
            this.bitisTarihi = bitisTarihi;
        }

    }
}
