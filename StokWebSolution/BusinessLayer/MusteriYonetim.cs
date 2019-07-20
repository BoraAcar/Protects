using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MusteriYonetim
    {
        private Repository<Musteri> repo_musteri = new Repository<Musteri>();
        
        public List<Musteri> Listeleme()
        {
            return repo_musteri.List();
        }

        public Musteri MusteriBul(string adsoyad)
        {
            return repo_musteri.Find(x => x.Ad_Soyad == adsoyad);
        }

        public void MusteriSil(Musteri musteri)
        {
            repo_musteri.Delete(musteri);
        }
    }
}
