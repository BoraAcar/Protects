using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UrunYonetim
    {
        private Repository<Urun> repo_urun = new Repository<Urun>();

        public List<Urun> Listeleme()
        {
            return repo_urun.List();
        }

        public void Sil(int id)
        {
            Urun urun= repo_urun.Find(x=>x.id==id);
            repo_urun.Delete(urun);
        }

        public void Guncelle(int id,Urun guncel_urun)
        {
            Urun urun = repo_urun.Find(x => x.id == id);
            urun.Urun_Adi = guncel_urun.Urun_Adi;
            //urun.Kategori = guncel_urun.Kategori;
            //urun.Musteri = guncel_urun.Musteri;
            urun.Miktar = guncel_urun.Miktar;
            urun.Fiyat = guncel_urun.Fiyat;
            //urun.id = guncel_urun.id;

            repo_urun.Save();
        }

        public Urun Bul(int id)  // id'ye göre bulma
        {
            Urun urun = repo_urun.Find(x => x.id == id);
            return urun;
        }

        public void Kaydet(Urun urun)
        {
            repo_urun.Insert(urun);
        }

        public List<Urun> Bul(string MusteriAdSoyad)  // ad soyada göre bulma
        {
             List<Urun> urunlistesi = repo_urun.List(x => x.Musteri.Ad_Soyad == MusteriAdSoyad);

            return urunlistesi;
        }

    }
}
