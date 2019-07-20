using BusinessLayer;
using Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StokProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UrunYonetim urunyonetim = new UrunYonetim();

            return View(urunyonetim.Listeleme().OrderBy(x=>x.Fiyat).ToList());
        }

        public ActionResult KategorikListe(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KategoriYonetim ky = new KategoriYonetim();
            Kategori kat = ky.KategorikListe(id.Value);

            if (kat == null)
            {
                return HttpNotFound();
            }

            return View("Index", kat.Urunler);



        }

        public ActionResult Sil(int? id)
        {
            UrunYonetim urunyonetim = new UrunYonetim();
            urunyonetim.Sil(id.Value);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Guncelle(int? id)
        {
            UrunYonetim urunyonetim = new UrunYonetim();
            Urun urun = urunyonetim.Bul(id.Value);

            return View(urun);
        }

        [HttpPost]
        public ActionResult Guncelle(Urun urun)
        {
            UrunYonetim urunyonetim = new UrunYonetim();
            urunyonetim.Guncelle(urun.id,urun);

            return RedirectToAction("Index","Home");
        }

        public ActionResult UrunKayit()
        {
            MusteriYonetim musteriyonetim = new MusteriYonetim();
            List<Musteri> musterilistesi = musteriyonetim.Listeleme();
            ViewBag.musteriler = musterilistesi.Select(x=>x.Ad_Soyad);

            KategoriYonetim kategoriyonetim = new KategoriYonetim();
            List<Kategori> kategorilistesi = kategoriyonetim.Listeleme();
            ViewBag.kategoriler = kategorilistesi.Select(x => x.Baslik);

            return View();
        }

        [HttpPost]
        public ActionResult UrunKayit(Urun urun)
        {
            MusteriYonetim musteriyonetim = new MusteriYonetim();
            Musteri musteri = musteriyonetim.MusteriBul(urun.Musteri.Ad_Soyad);

            KategoriYonetim kategoriyonetim = new KategoriYonetim();
            Kategori kategori = kategoriyonetim.KategoriBul(urun.Kategori.Baslik);

            urun.Kategori.id = kategori.id;
            urun.Musteri.id = musteri.id;
            urun.Musteri.Adres = musteri.Adres;
            urun.Musteri.Tel_No = musteri.Tel_No;

            UrunYonetim urunyonetim = new UrunYonetim();
            urunyonetim.Kaydet(urun);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult MusteriSil()
        {
            MusteriYonetim musteriyonetim = new MusteriYonetim();
            List<Musteri> musterilistesi = musteriyonetim.Listeleme();

            ViewBag.musteriler = musterilistesi.Select(x => x.Ad_Soyad);

            return View();
        }

        [HttpPost]
        public ActionResult MusteriSil(Musteri silinecekmusteri)
        {
            UrunYonetim urunyonetim = new UrunYonetim();
            List<Urun> urunler = urunyonetim.Bul(silinecekmusteri.Ad_Soyad);

            foreach (var item in urunler)
            {
                urunyonetim.Sil(item.id);
            }

            MusteriYonetim musteriyonetim = new MusteriYonetim();
            Musteri musteri = musteriyonetim.MusteriBul(silinecekmusteri.Ad_Soyad);

            musteriyonetim.MusteriSil(musteri);

            return RedirectToAction("Index", "Home");
        }
    }
  
}