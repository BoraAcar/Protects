using MyEvernote.WebApp.ViewModels;
using MyEvernoteBusinessLayer;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Tempdata ile kategorideki notları listeleme...
            /*if(TempData["mm"]!=null)
            {
                return View(TempData["mm"] as List<Note>);  // Kategori seçilirse  ona göre notlar listelenecek...
            }*/


            NoteManager nm = new NoteManager();
            return View(nm.GetAllNotes().OrderByDescending(x=>x.ModifiedOn).ToList());
            
            //bunun ile de yapılabilir ...return View(nm.GetAllNoteQueryable().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value); // id nullable olduğu için .Value demeliyiz...

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View("Index",cat.Notes.OrderByDescending(x=>x.ModifiedOn).ToList());

        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
            return View("Index",nm.GetAllNotes().OrderByDescending(x => x.LikeCount).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Username=="aaa")
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı kullanılıyor!");
                }

                if(model.EMail=="aa@aa.com")
                {
                    ModelState.AddModelError("", "Bu e-Posta kullanılıyor!");
                }

                foreach (var item in ModelState)
                {
                    if(item.Value.Errors.Count>0)
                    {
                        return View(model);
                    }
                }

                return RedirectToAction("RegisterOk");
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            return View();
        }
    }
}