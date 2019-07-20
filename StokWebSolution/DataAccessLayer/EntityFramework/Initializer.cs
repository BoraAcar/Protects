using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class Initializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 8; i++)
            {
                Musteri musteri = new Musteri();
                musteri.Ad_Soyad = FakeData.NameData.GetFullName();
                musteri.Tel_No = FakeData.PhoneNumberData.GetPhoneNumber();
                musteri.Adres = FakeData.PlaceData.GetAddress();

                
                context.Musteriler.Add(musteri);
            }

            context.SaveChanges();

            List<Musteri> musterilistesi = context.Musteriler.ToList();

            for (int i = 0; i < 4; i++)
            {
                Kategori kategori = new Kategori();

                kategori.Baslik = FakeData.NameData.GetCompanyName();
                context.Kategoriler.Add(kategori);

                for (int j = 0; j < 6; j++)
                {
                    Musteri musterisi = musterilistesi[FakeData.NumberData.GetNumber(0, musterilistesi.Count - 1)];

                    Urun urun = new Urun();

                    urun.Urun_Adi = FakeData.NameData.GetCompanyName();
                    urun.Fiyat = FakeData.NumberData.GetNumber(100, 9000);
                    urun.Miktar = FakeData.NumberData.GetNumber(0, 40);
                    urun.Musteri = musterisi;
                    urun.Kategori = kategori;


                    context.Urunler.Add(urun);
                    kategori.Urunler.Add(urun);

                }
            }

            context.SaveChanges();

        }
    }
}
