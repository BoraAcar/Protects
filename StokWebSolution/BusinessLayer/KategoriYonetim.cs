using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KategoriYonetim
    {
        private Repository<Kategori> repo_kategori = new Repository<Kategori>();

        public List<Kategori> Listeleme()
        {
            return repo_kategori.List();
        }

        public Kategori KategorikListe(int id)
        {
            return repo_kategori.Find(x => x.id == id);
        }

        public Kategori KategoriBul(string baslik)
        {
            return repo_kategori.Find(x => x.Baslik == baslik);
        }

    }
}
